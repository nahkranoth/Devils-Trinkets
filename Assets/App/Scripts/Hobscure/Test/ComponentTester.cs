using UnityEngine;
using System.Collections;

namespace Hobscure.Test
{
    public class ComponentTester : MonoBehaviour
    {
        public Object data;

        // Use this for initialization
        void Start()
        {
            var component = GetComponent<iComponent>();
            var dat = Object.Instantiate(data) as iTestData;
            component.ApplyModel(dat.GetData()[0]);
        }

    }
}