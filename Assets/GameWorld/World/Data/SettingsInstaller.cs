using UnityEngine;
using Zenject;
using Hobscure.Items;
using Hobscure.Player;
using Hobscure.Objects;

namespace Hobscure.Main {
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
    public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        public ItemDataCollection ItemCollection;

        public ObjectCollection ObjectCollection;

        public PlayerSettings PlayerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(ItemCollection);
            Container.BindInstance(ObjectCollection);
            Container.BindInstance(PlayerSettings);
        }
    }
}