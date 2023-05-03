using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Factories;
using Unity.Collections;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Scripts
{
    public class DrawLineService : ITickable
    {
        private StartFinishProvider _startFinishProvider;
        private readonly LineFactory _lineFactory;
        private List<DrawLine> _lines = new List<DrawLine>();
        private Dictionary<Unit, DrawLine> _playerLineDictionary = new Dictionary<Unit, DrawLine>();
        private DrawLine _currentLine;
        private Unit _currentPlayer;
        private bool _isDrawing;

        public DrawLineService(StartFinishProvider startFinishProvider, LineFactory lineFactory)
        {
            _startFinishProvider = startFinishProvider;
            _lineFactory = lineFactory;
        }
        

        //todo: временный код для тестов
        private void StartPlayerMoving()
        {
            foreach (var unit in _playerLineDictionary.Keys)
            {
                DrawLine line = _playerLineDictionary[unit];
                unit.InitUnitMoving(GetPointsFromLine(line.LineRenderer));
            }
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
            return _startFinishProvider.PlayerFinishDictionary[_currentPlayer].IsPointed;
        }

        private bool CheckStartLinePos()
        {
            var players = _startFinishProvider.PlayerFinishDictionary.Keys;
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
                    
                    //todo: временный код для тестов
                    if (_playerLineDictionary.Count == 2)
                    {
                        StartPlayerMoving();
                    }
                }
            }
        }
    }
}