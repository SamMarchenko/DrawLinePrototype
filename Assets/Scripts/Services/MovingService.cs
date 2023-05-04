using System;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using Views;

namespace Services
{
    public class MovingService
    {
        private readonly PlayersFinishesProvider _playersFinishesProvider;
        private readonly DrawLineService _drawLineService;
        private Dictionary<UnitView, List<Vector3>> _playersPaths;
        private UnitView[] _players;

        public Action OnFailMoved;
        public Action OnSuccessMoved;


        public MovingService(PlayersFinishesProvider playersFinishesProvider, DrawLineService drawLineService)
        {
            _playersFinishesProvider = playersFinishesProvider;
            _drawLineService = drawLineService;
        }

        public void BeginMove()
        {
            _players = _playersFinishesProvider.GetUnits();
            SubscribePlayers();
            _playersPaths = _drawLineService.PlayerPathDictionary;

            foreach (var player in _players)
            {
                var path = _playersPaths[player];
                player.InitUnitMoving(path);
            }
        }

        public void StopMove()
        {
            foreach (var player in _players)
            {
                player.StopMoving();
            }
        }

        private void SubscribePlayers()
        {
            foreach (var player in _players)
            {
                player.OnFinish += OnFinish;
                player.OnCollision += OnCollisionWithPlayer;
            }
        }

        private void OnCollisionWithPlayer()
        {
            OnFailMoved?.Invoke();
            UnSubscribePlayers();
        }

        private void UnSubscribePlayers()
        {
            foreach (var player in _players)
            {
                player.OnFinish -= OnFinish;
                player.OnCollision -= OnCollisionWithPlayer;
            }
        }

        private void OnFinish()
        {
            OnSuccessMoved?.Invoke();
            UnSubscribePlayers();
        }
    }
}