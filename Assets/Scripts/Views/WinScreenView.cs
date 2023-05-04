using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class WinScreenView : MonoBehaviour
    {
        [SerializeField] private Button _nextLvlBtn;
        public Button NextLvlBtn => _nextLvlBtn;
    }
}