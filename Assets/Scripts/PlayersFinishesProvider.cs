using System.Collections.Generic;
using System.Linq;
using Data;
using Factories;
using Views;

namespace Scripts
{
    public class PlayersFinishesProvider
    {
        private readonly PlayerFinishFactory _factory;
        private readonly SpawnPositions _spawnPositions;
        private readonly LevelColorSettings _levelColorSettings;
        public Dictionary<UnitView, FinishView> PlayerFinishDictionary = new Dictionary<UnitView, FinishView>();

        public PlayersFinishesProvider(PlayerFinishFactory factory, SpawnPositions spawnPositions, LevelColorSettings levelColorSettings)
        {
            _factory = factory;
            _spawnPositions = spawnPositions;
            _levelColorSettings = levelColorSettings;
            Init();
        }

        public UnitView[] GetUnits()
        {
            UnitView[] units = new UnitView[PlayerFinishDictionary.Count];

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
        }
    }
}