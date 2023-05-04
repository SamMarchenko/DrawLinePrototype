using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class FailScreenView : MonoBehaviour
    {
        [SerializeField] private Button _repeatLvlButton;
        public Button RepeatLvlBtn => _repeatLvlButton;
    }
}