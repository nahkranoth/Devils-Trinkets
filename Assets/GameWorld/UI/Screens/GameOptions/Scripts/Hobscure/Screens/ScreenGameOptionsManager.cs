using UnityEngine;
using System.Collections;
using Zenject;

namespace Hobscure.Screens
{
    public class ScreenGameOptionsManager : IScreenManager
    {

        [Inject]
        ScreenGameOptions view;

        public void ConstructViewModel()
        {
           
        }

        public void Show()
        {
            view.gameObject.SetActive(true);
        }

        public void Close()
        {
            view.gameObject.SetActive(false);
        }

    }
}