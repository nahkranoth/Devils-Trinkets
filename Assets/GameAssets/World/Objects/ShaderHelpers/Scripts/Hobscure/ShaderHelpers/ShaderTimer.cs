using UnityEngine;
using System.Collections;


namespace Hobscure.ShaderHelpers {
    public class ShaderTimer : MonoBehaviour
    {
        public float timer;
        private float time;

        void Start()
        {
            StartCoroutine(RunTimer());
        }


        IEnumerator RunTimer()
        {
            while (true)
            {
                time += timer;
                yield return new WaitForSeconds(timer);
            }
        }
    }
}