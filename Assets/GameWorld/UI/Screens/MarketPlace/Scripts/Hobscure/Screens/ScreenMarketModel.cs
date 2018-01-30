using UnityEngine;
using System.Collections;
using Hobscure.UI;

public class ScreenMarketModel: iComponentModel {

    public ScrollListModel localInventoryScroll;
    public ScrollListModel shopInventoryScroll;
    public float cashAmount;


    public ScreenMarketModel(int maxPlayerContainAmount, int maxShopContainAmount)
    {
        localInventoryScroll = new ScrollListModel(maxPlayerContainAmount);
        shopInventoryScroll = new ScrollListModel(maxShopContainAmount);
    }


   
}
