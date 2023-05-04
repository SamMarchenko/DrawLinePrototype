using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class LevelColorSettings : ScriptableObject
    {
        public Color[] PlayersCollor;
        public Color[] FinishCollor;
    }
}