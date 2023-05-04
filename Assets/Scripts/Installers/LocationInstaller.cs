using Scripts.Factories;
using Scripts.States;
using UnityEngine;
using Zenject;

namespace Scripts.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Unit _playerPrefab;
        [SerializeField] private Finish _finishPrefab;
        [SerializeField] private DrawLine _linePrefab;
        [SerializeField] private SpawnPositions _spawnPositions;
        [SerializeField] private CoreUIController _coreUIController;
        public override void InstallBindings()
        {
            Container.BindInstance(_playerPrefab);
            Container.BindInstance(_finishPrefab);
            Container.BindInstance(_linePrefab);
            Container.BindInstance(_spawnPositions);
            Container.BindInstance(_coreUIController);
         
            
            
            Container.BindInterfacesAndSelfTo<PlayerFinishFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LineFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayersFinishesProvider>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<DrawLineService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MovingService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<FailScreenService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WinScreenService>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<GameCycleController>().AsSingle().NonLazy();
        }
    }
}