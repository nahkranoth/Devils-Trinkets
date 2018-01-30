using UnityEngine;
using Zenject;
using Hobscure.Main;
using Hobscure.World.Market;
using Hobscure.Screens;
using Hobscure.UI;
using Hobscure.Player;
using Hobscure.NPC;
using Hobscure.Items;
using Hobscure.Objects;

namespace Zenject { 
    public class ZenjectInstaller : MonoInstaller<ZenjectInstaller>
    {
        //screens
        public GameObject prefabInventoryTransfer;
        public GameObject prefabPlayerInventory;
        public GameObject prefabNPCInteraction;
        public GameObject prefabGameOptions;
        public GameObject prefabMarket;
        public GameObject prefabMarketInfo;
        public GameObject prefabHeader;
        public GameObject prefabSubmenuTabs;

        //components
        public GameObject prefabButton;
        public GameObject prefabIconButton;
        public GameObject prefabIconStateButton;
        public GameObject prefabScrollList;
        public GameObject prefabMachineProcessorScreen;
        public GameObject prefabTextField;
        public GameObject itemContainer;
        
        //object prefabs
        public GameObject prefabPlayer;
        public GameObject prefabNPC;

        public override void InstallBindings()
        {
            //States
            Container.Bind<InventoryState>().AsSingle();

            //Game
            Container.Bind<InputManager>().AsSingle();

            //Player
            Container.Bind<PlayerManager>().FromPrefab(prefabPlayer).AsSingle();
            Container.Bind<PlayerInventoryManager>().AsSingle();

            //NPC
            Container.Bind<NPCManager>().FromPrefab(prefabNPC);

            //World
            Container.Bind<ObjectManager>().AsSingle();
            Container.Bind<ItemManager>().AsSingle();
            Container.Bind<PlayerSettingsManager>().AsSingle();
            Container.Bind<MarketManager>().AsSingle();

            //UI Screens
            Container.Bind<UIStateManager>().AsSingle();

            Container.Bind<ScreenHeader>().FromPrefab(prefabHeader).AsSingle();
            Container.Bind<ScreenHeaderManager>().AsSingle();

            Container.Bind<ScreenSubmenuTabs>().FromPrefab(prefabSubmenuTabs).AsSingle();
            Container.Bind<ScreenSubmenuTabsManager>().AsSingle();

            Container.Bind<ScreenInventoryTransfer>().FromPrefab(prefabInventoryTransfer).AsSingle();
            Container.Bind<ScreenInventoryTransferManager>().AsSingle();

            Container.Bind<ScreenPlayerInventory>().FromPrefab(prefabPlayerInventory).AsSingle();
            Container.Bind<ScreenPlayerInventoryManager>().AsSingle();

            Container.Bind<ScreenNPCInteraction>().FromPrefab(prefabNPCInteraction).AsSingle();
            Container.Bind<ScreenNPCInteractionManager>().AsSingle();

            Container.Bind<ScreenGameOptions>().FromPrefab(prefabGameOptions).AsSingle();
            Container.Bind<ScreenGameOptionsManager>().AsSingle();

            Container.Bind<ScreenMarket>().FromPrefab(prefabMarket).AsSingle();
            Container.Bind<ScreenMarketManager>().AsSingle();
            Container.Bind<MarketInfo>().FromPrefab(prefabMarketInfo).AsSingle();

            //UI Components
            Container.Bind<GeneralButton>().FromPrefab(prefabButton);
            Container.Bind<IconButton>().FromPrefab(prefabIconButton);
            Container.Bind<IconStateButton>().FromPrefab(prefabIconStateButton);

            Container.Bind<ScrollList>().FromPrefab(prefabScrollList);
            Container.Bind<ScreenMachineProcessor>().FromPrefab(prefabMachineProcessorScreen);
            Container.Bind<CustomTextField>().FromPrefab(prefabTextField);
            Container.Bind<ItemContainer>().FromPrefab(itemContainer);

            //Signals
            Container.Bind<ScreenInventoryTransferSignals>().AsSingle();

        }
    }
}