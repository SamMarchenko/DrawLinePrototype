using UnityEngine;
using Zenject;

namespace Scripts.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Unit _playerPrefab;
        [SerializeField] private Finish _finishPrefab;
        public override void InstallBindings()
        {
            Container.BindInstance(_playerPrefab);
            Container.BindInstance(_finishPrefab);

            Container.BindInterfacesAndSelfTo<PlayerFinishFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StartFinishProvider>().AsSingle().NonLazy();
        }
    }
}