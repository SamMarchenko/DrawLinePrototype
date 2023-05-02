using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class DrawLineService : MonoBehaviour
    {
        [SerializeField] private StartFinishProvider _startFinishProvider;
        [SerializeField] private DrawLine _linePrefab;
        [SerializeField] private List<DrawLine> _lines = new List<DrawLine>();
        private Dictionary<Unit, DrawLine> _playerLineDictionary = new Dictionary<Unit, DrawLine>();
        [SerializeField] private DrawLine _currentLine;
        [SerializeField] private Unit _currentPlayer;
        private bool _isDrawing;


        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (!_isDrawing)
                {
                    if (CheckStartLinePos() == false)
                        return;

                    if (CheckPlayerHasLine())
                        return;

                    CreateLine();
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
                }
            }
        }

        private bool CheckPlayerHasLine()
        {
            return _playerLineDictionary.ContainsKey(_currentPlayer);
        }

        private void CreateLine()
        {
            _currentLine = Instantiate(_linePrefab);
            _currentLine.Init(transform.position);
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
            Destroy(_currentLine.gameObject);
            _currentLine = null;
            _currentPlayer = null;
        }
    }
}