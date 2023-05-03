using Scripts.Data;
using UnityEngine;

namespace Scripts
{
    public class PlayerFinishFactory
    {
        private readonly Unit _playerPrefab;
        private readonly Finish _finishPrefab;
        private readonly LevelSettings _levelSettings;

        public PlayerFinishFactory(Unit playerPrefab, Finish finishPrefab, LevelSettings levelSettings)
        {
            _playerPrefab = playerPrefab;
            _finishPrefab = finishPrefab;
            _levelSettings = levelSettings;
        }

        public Unit GetPlayer(int index, Color color)
        {
            return CreatePlayer(index, color);
        }

        public Finish GetFinish(int index, Color color)
        {
            return CreateFinish(index, color);
        }

        private Unit CreatePlayer(int index, Color color)
        {
            var player = MonoBehaviour.Instantiate(_playerPrefab);
            player.transform.position = _levelSettings.PlayersSpawnPos[index].position;
            player.SpriteRenderer.color = color;
            return player;
        }

        private Finish CreateFinish(int index, Color color)
        {
            var finish = MonoBehaviour.Instantiate(_finishPrefab);
            finish.transform.position = _levelSettings.FinishSpawnPos[index].position;
            finish.SpriteRenderer.color = color;
            return finish;
        }
    }
}