using System;
using Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

namespace Services
{
    public class WinScreenService : IDisposable
    {
        private WinScreenView _view;
        private readonly WinScreenView _viewprefab;
        private readonly Canvas _lvlUICanvas;
        //private string _currentlLevelName;
        private int _numberActiveScene;
        private string _nextLevelName;

        public void Init(WinScreenView view)
        {
            _view = view;
            _view.NextLvlBtn.onClick.AddListener(LoadNextLevel);
            _numberActiveScene = SceneManager.GetActiveScene().buildIndex + 1;

            _nextLevelName = _numberActiveScene == SceneManager.sceneCountInBuildSettings
                ? "Level_1"
                : "Level_" + (_numberActiveScene + 1);
        }

        public void Show() => 
            _view.gameObject.SetActive(true);

        public void Hide() => 
            _view.gameObject.SetActive(false);

        public void Dispose() => 
            _view.NextLvlBtn.onClick.RemoveAllListeners();

        private void LoadNextLevel() => 
            SceneTransition.SwitchToScene(_nextLevelName);
    }
}