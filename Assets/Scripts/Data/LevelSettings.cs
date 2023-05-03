using UnityEngine;

namespace Scripts.Data
{
    [CreateAssetMenu]
    public class LevelSettings : ScriptableObject
    {
        public Transform[] PlayersSpawnPos;
        public Transform[] FinishSpawnPos;
    }
}