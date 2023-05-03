using Scripts.Factories;
using UnityEngine;
using Zenject;

namespace Scripts.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Unit _playerPrefab;
        [SerializeField] private Finish _finishPrefab;
        [SerializeField] private DrawLine _linePrefab;
        public override void InstallBindings()
        {
            Container.BindInstance(_playerPrefab);
            Container.BindInstance(_finishPrefab);
            Container.BindInstance(_linePrefab);

            Container.BindInterfacesAndSelfTo<PlayerFinishFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LineFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StartFinishProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DrawLineService>().AsSingle().NonLazy();
        }
    }
}