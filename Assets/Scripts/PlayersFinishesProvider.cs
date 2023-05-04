using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Data;
using UnityEngine;

namespace Scripts
{
    public class PlayersFinishesProvider
    {
        private readonly PlayerFinishFactory _factory;
        private readonly SpawnPositions _spawnPositions;
        private readonly LevelColorSettings _levelColorSettings;
        public Dictionary<Unit, Finish> PlayerFinishDictionary = new Dictionary<Unit, Finish>();

        public PlayersFinishesProvider(PlayerFinishFactory factory, SpawnPositions spawnPositions, LevelColorSettings levelColorSettings)
        {
            _factory = factory;
            _spawnPositions = spawnPositions;
            _levelColorSettings = levelColorSettings;
            Init();
        }

        public Unit[] GetUnits()
        {
            Unit[] units = new Unit[PlayerFinishDictionary.Count];

            for (var i = 0; i < PlayerFinishDictionary.Keys.Count; i++)
            {
                units[i] = PlayerFinishDictionary.ElementAt(i).Key;
            }

            return units;
        }

        public int GetPlayersCount()
        {
            return PlayerFinishDictionary.Count;
        }

        private void Init()
        {
            for (var i = 0; i < _spawnPositions.PlayersSpawnPos.Length; i++)
            {
                var player = _factory.GetPlayer(i, _levelColorSettings.PlayersCollor[i]);
                var finish = _factory.GetFinish(i, _levelColorSettings.FinishCollor[i]);
                PlayerFinishDictionary.Add(player,finish);
            }
            // PlayerFinishDictionary.Add(_factory.GetPlayer(0, ), _factory.GetFinish(0, Color.blue));
            // PlayerFinishDictionary.Add(_factory.GetPlayer(1, Color.magenta), _factory.GetFinish(1, Color.red));
        }
    }
}