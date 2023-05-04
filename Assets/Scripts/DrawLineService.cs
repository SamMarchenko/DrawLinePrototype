using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Factories;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Scripts
{
    public class DrawLineService : ITickable
    {
        private PlayersFinishesProvider _playersFinishesProvider;
        private readonly LineFactory _lineFactory;
        private List<DrawLine> _lines = new List<DrawLine>();
        private Dictionary<Unit, DrawLine> _playerLineDictionary = new Dictionary<Unit, DrawLine>();
        private Dictionary<Unit, List<Vector3>> _playersPathDictionary = new Dictionary<Unit, List<Vector3>>();
        private DrawLine _currentLine;
        private Unit _currentPlayer;
        private bool _isDrawing;

        public bool CanDraw;
        public Dictionary<Unit ,List<Vector3>> PlayerPathDictionary => _playersPathDictionary;

        public Action OnFinishDrawingAllLines;

        public DrawLineService(PlayersFinishesProvider playersFinishesProvider, LineFactory lineFactory)
        {
            _playersFinishesProvider = playersFinishesProvider;
            _lineFactory = lineFactory;
        }
        

        private List<Vector3> GetPointsFromLine(LineRenderer line)
        {
            Vector3[] pathPoints = new Vector3[line.positionCount];

            line.GetPositions(pathPoints);
            return pathPoints.ToList();
        }

        private bool CheckPlayerHasLine()
        {
            return _playerLineDictionary.ContainsKey(_currentPlayer);
        }

        private void DrawLine()
        {
            _currentLine = _lineFactory.CreateLine(_currentPlayer.SpriteRenderer.color);
            _currentLine.Init();
        }

        private bool CheckFinishLinePos()
        {
            return _playersFinishesProvider.PlayerFinishDictionary[_currentPlayer].IsPointed;
        }

        private bool CheckStartLinePos()
        {
            var players = _playersFinishesProvider.PlayerFinishDictionary.Keys;
            foreach (var player in players)
            {
                if (player.IsPointed)
                {
                    _currentPlayer = player;
                    return true;
                }
            }

            return false;
        }

        private void DestroyLine()
        {
            Object.Destroy(_currentLine.gameObject);
            _currentLine = null;
            _currentPlayer = null;
        }

        public void Tick()
        {
            if (!CanDraw)
                return;

            if (Input.GetMouseButton(0))
            {
                if (!_isDrawing)
                {
                    if (CheckStartLinePos() == false)
                        return;

                    if (CheckPlayerHasLine())
                        return;

                    DrawLine();
                    _isDrawing = true;
                }
                else
                {
                    _currentLine.Draw();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (!_isDrawing)
                {
                    return;
                }

                _isDrawing = false;
                if (CheckFinishLinePos() == false)
                {
                    DestroyLine();
                }
                else
                {
                    _lines.Add(_currentLine);
                    _playerLineDictionary.Add(_currentPlayer, _currentLine);
                    
                    if (CheckAllPlayersDraw())
                    {
                        GetAllPathsFromLines();
                        OnFinishDrawingAllLines?.Invoke();
                    }
                }
            }
        }

        private bool CheckAllPlayersDraw()
        {
            return _playerLineDictionary.Count == _playersFinishesProvider.GetPlayersCount();
        }

        private void GetAllPathsFromLines()
        {
            foreach (var (key, value) in _playerLineDictionary)
            {
                _playersPathDictionary.Add(key, GetPointsFromLine(value.LineRenderer));
            }
        }
    }
}