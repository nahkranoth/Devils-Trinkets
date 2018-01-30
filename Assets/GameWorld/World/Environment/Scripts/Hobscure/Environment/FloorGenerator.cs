using UnityEngine;
using System.Collections;

namespace Hobscure.Environment { 
    public class FloorGenerator : MonoBehaviour {

        public GameObject floorPrefab;

        // Use this for initialization
        void Start () {
            for (int j = 0; j < 22; j++)
            {
                for (int i = 0; i < 22; i++)
                {
                    var floorBlock = Instantiate(floorPrefab);
                    floorBlock.transform.SetParent(transform, false);
                    floorBlock.transform.position = new Vector3(j, 0f, i);
                }
            }
        }
    }
}