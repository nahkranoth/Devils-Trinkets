using UnityEngine;
using System.Collections;
using System.Linq;
using Zenject;
using Kuchen;
using Hobscure.UI;
using Hobscure.Main;
using Hobscure.Player;

namespace Hobscure.Screens
{
    public class ScreenHeader : MonoBehaviour, iComponent
    {
        [Inject]
        CustomTextField textField;

        [Inject]
        ScreenHeaderManager screenHeaderManager;

        [SerializeField]
        Transform cashTextHolder;

        [HideInInspector]
        public ScreenPlayerInventoryModel model;

        [SerializeField]
        CustomTextFieldStyle headerCashTxtStyle;

        void Start()
        {
            textField.transform.SetParent(cashTextHolder, false);
        }

        public void ApplyModel(iComponentModel data)
        {
            model = data as ScreenPlayerInventoryModel;
            textField.SetText(model.cashAmount.ToString()) ;
            textField.SetTextStyle(headerCashTxtStyle);
        }
    }
}
