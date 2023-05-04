using Factories;
using Scripts;
using Services;
using UnityEngine;
using Views;
using Zenject;

namespace Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private UnitView _playerPrefab;
        [SerializeField] private FinishView finishViewPrefab;
        [SerializeField] private DrawLineView lineViewPrefab;
        [SerializeField] private SpawnPositions _spawnPositions;
        [SerializeField] private CoreUIController _coreUIController;

        public override void InstallBindings()
        {
            BindViewPrefabs();
            Container.BindInstance(_spawnPositions);
            Container.BindInstance(_coreUIController);


            BindFactories();


            Container.BindInterfacesAndSelfTo<PlayersFinishesProvider>().AsSingle().NonLazy();

            BindServices();

            Container.BindInterfacesAndSelfTo<GameCycleController>().AsSingle().NonLazy();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<DrawLineService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MovingService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<FailScreenService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WinScreenService>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<PlayerFinishFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LineFactory>().AsSingle().NonLazy();
        }

        private void BindViewPrefabs()
        {
            Container.BindInstance(_playerPrefab);
            Container.BindInstance(finishViewPrefab);
            Container.BindInstance(lineViewPrefab);
        }
    }
}