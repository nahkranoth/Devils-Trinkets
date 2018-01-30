using UnityEngine;
using System.Collections;
using Zenject;

namespace Hobscure.Screens { 
    public class UIBuilder : MonoBehaviour {

        [Inject]
        ScreenPlayerInventory inventoryScreen;

        [Inject]
        ScreenInventoryTransfer transferScreen;

        [Inject]
        ScreenNPCInteraction NPScreen;

        [Inject]
        ScreenGameOptions GameOptionsScreen;

        [Inject]
        ScreenMarket MarketScreen;

        [Inject]
        ScreenHeader HeaderScreen;

        [Inject]
        ScreenSubmenuTabs SubmenuTabsScreen;

        //Holders
        [SerializeField]
        Transform inventoryHolder;

        [SerializeField]
        Transform inventoryTransferHolder;

        [SerializeField]
        Transform NPCInteractionHolder;

        [SerializeField]
        Transform gameOptionsHolder;

        [SerializeField]
        Transform MarketOptionHolder;

        [SerializeField]
        Transform HeaderHolder;

        [SerializeField]
        Transform SubmenuTabsHolder;

        void Start()
        {
            inventoryScreen.transform.SetParent(inventoryHolder, false);
            inventoryScreen.gameObject.SetActive(false);

            NPScreen.transform.SetParent(NPCInteractionHolder, false);
            NPScreen.gameObject.SetActive(false);

            transferScreen.transform.SetParent(inventoryTransferHolder, false);
            transferScreen.gameObject.SetActive(false);

            GameOptionsScreen.transform.SetParent(gameOptionsHolder, false);
            GameOptionsScreen.gameObject.SetActive(false);

            MarketScreen.transform.SetParent(MarketOptionHolder, false);
            MarketScreen.gameObject.SetActive(false);

            HeaderScreen.transform.SetParent(HeaderHolder, false); //dont need to set invisible because, allways visible

            SubmenuTabsScreen.transform.SetParent(SubmenuTabsHolder, false);
            SubmenuTabsScreen.gameObject.SetActive(false);

        }

    }
}