using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class WinScreenView : MonoBehaviour
    {
        [SerializeField] private Button _nextLvlBtn;
        public Button NextLvlBtn => _nextLvlBtn;
    }
}