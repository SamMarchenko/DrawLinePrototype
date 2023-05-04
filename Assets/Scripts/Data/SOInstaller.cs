using UnityEngine;
using Zenject;

namespace Data
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private LevelColorSettings levelColorSettings;
        public override void InstallBindings()
        {
            Container.BindInstance(levelColorSettings);
        }
    }
}