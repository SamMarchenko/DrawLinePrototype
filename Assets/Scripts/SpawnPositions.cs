using UnityEngine;

namespace Scripts
{
    public class SpawnPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] _playersSpawnPos;
        [SerializeField] private Transform[] _finishSpawnPos;

        public Transform[] PlayersSpawnPos => _playersSpawnPos;
        public Transform[] FinishSpawnPos => _finishSpawnPos;
    }
}