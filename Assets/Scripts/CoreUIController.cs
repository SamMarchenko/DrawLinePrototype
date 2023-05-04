using Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;
using Zenject;

namespace Scripts
{
    public class CoreUIController : MonoBehaviour
    {
        [SerializeField] private WinScreenView _winScreenView;
        [SerializeField] private FailScreenView _failScreenView;
        [SerializeField] private TMP_Text _currentLevelNumber;
        private WinScreenService _winScreenService;
        private FailScreenService _failScreenService;

        [Inject]
        public void Construct(WinScreenService winScreenService, FailScreenService failScreenService)
        {
          _winScreenService = winScreenService;
          _failScreenService = failScreenService;
          _winScreenService.Init(_winScreenView);
          _failScreenService.Init(_failScreenView);

          _currentLevelNumber.text = $"Level: {SceneManager.GetActiveScene().buildIndex + 1} ";
        }
    }
}