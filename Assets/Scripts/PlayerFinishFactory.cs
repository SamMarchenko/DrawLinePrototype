using UnityEngine;

namespace Scripts
{
    public class PlayerFinishFactory
    {
        private readonly Unit _playerPrefab;
        private readonly Finish _finishPrefab;

        public PlayerFinishFactory(Unit playerPrefab, Finish finishPrefab)
        {
            _playerPrefab = playerPrefab;
            _finishPrefab = finishPrefab;
        }

        public Unit CreatePlayer()
        {
           var player = MonoBehaviour.Instantiate(_playerPrefab);
           return player;
        }

        public Finish CreateFinish()
        {
            var finish = MonoBehaviour.Instantiate(_finishPrefab);
            return finish;
        }
    }
}