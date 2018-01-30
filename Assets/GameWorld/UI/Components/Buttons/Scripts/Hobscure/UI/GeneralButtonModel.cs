using UnityEngine;
using System.Collections;
namespace Hobscure.UI
{
    public class GeneralButtonModel
    {

        public string command;
        public string text;

        public GeneralButtonModel(string command, string text)
        {
            this.command = command;
            this.text = text;
        }

    }
}