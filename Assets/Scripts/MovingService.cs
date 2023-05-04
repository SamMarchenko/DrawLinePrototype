using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MovingService
    {
        private readonly PlayersFinishesProvider _playersFinishesProvider;
        private readonly DrawLineService _drawLineService;
        private Dictionary<Unit, List<Vector3>> _playersPaths;
        private Unit[] _players;

        public Action OnFailMoved;
        public Action OnSuccessMoved;


        public MovingService(PlayersFinishesProvider playersFinishesProvider, DrawLineService drawLineService)
        {
            _playersFinishesProvider = playersFinishesProvider;
            _drawLineService = drawLineService;
        }

        private void SubscribePlayers()
        {
            foreach (var player in _players)
            {
                player.OnFinish += OnFinish;
                player.OnCollisionWithPlayer += OnCollisionWithPlayer;
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
                player.OnCollisionWithPlayer -= OnCollisionWithPlayer;
            }
        }

        private void OnFinish()
        {
            OnSuccessMoved?.Invoke();
            UnSubscribePlayers();
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
    }
}