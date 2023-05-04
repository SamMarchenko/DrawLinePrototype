using System;
using UnityEngine.SceneManagement;
using Views;

namespace Services
{
    public class FailScreenService : IDisposable
    {
        private FailScreenView _view;
        private int _numberActiveScene;
        private string _currentLevelName;

        public void Init(FailScreenView view)
        {
            _view = view;
            _view.RepeatLvlBtn.onClick.AddListener(LoadCurrentLevel);
            
            _numberActiveScene = SceneManager.GetActiveScene().buildIndex + 1;
            _currentLevelName = "Level_" + (_numberActiveScene);
        }

        public void Show() => 
            _view.gameObject.SetActive(true);

        public void Hide() => 
            _view.gameObject.SetActive(false);

        public void Dispose() => 
            _view.RepeatLvlBtn.onClick.RemoveAllListeners();

        private void LoadCurrentLevel() => 
            SceneTransition.SwitchToScene(_currentLevelName);
    }
}