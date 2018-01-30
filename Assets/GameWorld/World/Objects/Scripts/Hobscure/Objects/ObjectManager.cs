using UnityEngine;
using System.Linq;
using System.Collections;

namespace Hobscure.Objects
{ 
    public class ObjectManager {

        readonly ObjectCollection collection;

        public ObjectManager(ObjectCollection collection)
        {
            this.collection = collection;
        }

        public GameObject GetObjectByName(string name)
        {
            if (collection.objectReferences.Any(i => i.idName == name))
            {
                GameObject returnItem = collection.objectReferences.Single(i => i.idName == name).obj;
                return returnItem;
            }
            else
            {
                Debug.LogError("Object could not be found by item name: " + name);
                return null;
            }
        }
    }
}