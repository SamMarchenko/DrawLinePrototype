using Scripts;
using UnityEngine;
using Views;

namespace Factories
{
    public class PlayerFinishFactory
    {
        private readonly UnitView _playerPrefab;
        private readonly FinishView _finishViewPrefab;
        private readonly SpawnPositions _spawnPositions;


        public PlayerFinishFactory(UnitView playerPrefab, FinishView finishViewPrefab, SpawnPositions spawnPositions )
        {
            _playerPrefab = playerPrefab;
            _finishViewPrefab = finishViewPrefab;
            _spawnPositions = spawnPositions;
        }

        public UnitView GetPlayer(int index, Color color) => 
            CreatePlayer(index, color);

        public FinishView GetFinish(int index, Color color) => 
            CreateFinish(index, color);

        private UnitView CreatePlayer(int index, Color color)
        {
            var player = MonoBehaviour.Instantiate(_playerPrefab);
            player.transform.position = _spawnPositions.PlayersSpawnPos[index].position;
            player.SpriteRenderer.color = color;
            return player;
        }

        private FinishView CreateFinish(int index, Color color)
        {
            var finish = MonoBehaviour.Instantiate(_finishViewPrefab);
            finish.transform.position = _spawnPositions.FinishSpawnPos[index].position;
            finish.SpriteRenderer.color = color;
            return finish;
        }
    }
}