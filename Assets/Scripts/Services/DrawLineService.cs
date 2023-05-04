using System;
using System.Collections.Generic;
using System.Linq;
using Factories;
using Scripts;
using UnityEngine;
using Views;
using Zenject;
using Object = UnityEngine.Object;

namespace Services
{
    public class DrawLineService : ITickable
    {
        private PlayersFinishesProvider _playersFinishesProvider;
        private readonly LineFactory _lineFactory;
        private List<DrawLineView> _lines = new List<DrawLineView>();
        private Dictionary<UnitView, DrawLineView> _playerLineDictionary = new Dictionary<UnitView, DrawLineView>();
        private Dictionary<UnitView, List<Vector3>> _playersPathDictionary = new Dictionary<UnitView, List<Vector3>>();
        private DrawLineView _currentLineView;
        private UnitView _currentPlayer;
        private bool _isDrawing;

        public bool CanDraw;
        public Dictionary<UnitView ,List<Vector3>> PlayerPathDictionary => _playersPathDictionary;

        public Action OnFinishDrawingAllLines;

        public DrawLineService(PlayersFinishesProvider playersFinishesProvider, LineFactory lineFactory)
        {
            _playersFinishesProvider = playersFinishesProvider;
            _lineFactory = lineFactory;
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
                    _currentLineView.Draw();
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
                    _lines.Add(_currentLineView);
                    _playerLineDictionary.Add(_currentPlayer, _currentLineView);
                    
                    if (CheckAllPlayersDraw())
                    {
                        GetAllPathsFromLines();
                        OnFinishDrawingAllLines?.Invoke();
                    }
                }
            }
        }

        private List<Vector3> GetPointsFromLine(LineRenderer line)
        {
            var pathPoints = new Vector3[line.positionCount];

            line.GetPositions(pathPoints);
            return pathPoints.ToList();
        }

        private bool CheckPlayerHasLine() => 
            _playerLineDictionary.ContainsKey(_currentPlayer);

        private void DrawLine()
        {
            _currentLineView = _lineFactory.CreateLine(_currentPlayer.SpriteRenderer.color);
            _currentLineView.Init();
        }

        private bool CheckFinishLinePos() => 
            _playersFinishesProvider.PlayerFinishDictionary[_currentPlayer].IsPointed;

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
            Object.Destroy(_currentLineView.gameObject);
            _currentLineView = null;
            _currentPlayer = null;
        }

        private bool CheckAllPlayersDraw() => 
            _playerLineDictionary.Count == _playersFinishesProvider.GetPlayersCount();

        private void GetAllPathsFromLines()
        {
            foreach (var (key, value) in _playerLineDictionary)
            {
                _playersPathDictionary.Add(key, GetPointsFromLine(value.LineRenderer));
            }
        }
    }
}