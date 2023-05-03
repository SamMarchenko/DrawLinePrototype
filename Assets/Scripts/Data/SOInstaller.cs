using UnityEngine;
using Zenject;

namespace Scripts.Data
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private LevelSettings _levelSettings;
        public override void InstallBindings()
        {
            Container.BindInstance(_levelSettings);
        }
    }
}