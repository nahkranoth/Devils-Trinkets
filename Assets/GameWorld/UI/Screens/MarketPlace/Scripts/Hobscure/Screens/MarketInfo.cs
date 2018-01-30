using UnityEngine;
using System.Linq;
using Zenject;
using Hobscure.UI;
using Hobscure.Items;
using System.Collections.Generic;

public class MarketInfo : MonoBehaviour {

    [SerializeField]
    private Transform priceHolder;

    [Inject]
    private CustomTextField priceTxt;

    [SerializeField]
    CustomTextFieldStyle textStyle;


	// Use this for initialization
	void Start () {
        priceTxt.transform.SetParent(priceHolder, false);
        priceTxt.SetText("0");
        priceTxt.SetTextStyle(textStyle);
    }
	
	public void SetPrice(float totalPrice)
    {
        //cumulate all item prices
        priceTxt.SetText(totalPrice.ToString() + "");
    }
}
