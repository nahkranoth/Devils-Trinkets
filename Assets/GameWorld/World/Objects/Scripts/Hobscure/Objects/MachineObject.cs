using UnityEngine;
using System.Collections;
using Zenject;
using Hobscure.Player;
using Hobscure.Items;

namespace Hobscure.Objects
{
    public class MachineObject : MonoBehaviour
    {
        [Inject]
        public PlayerManager playerManager;

        [HideInInspector]
        public ObjectInventoryManager inventoryManager;

        [HideInInspector]
        public bool lookedAt;

        [HideInInspector]
        public Item item;

        void Awake()
        {
            inventoryManager = GetComponent<ObjectInventoryManager>();
        }

        void Update()
        {
            if (playerManager.WorldObjectLookingAt() == this)
            {
                LookAt(true);
            }
            else
            {
                LookAt(false);
            }
        }

        public void LookAt(bool state)
        {
            lookedAt = state;
        }

    }
}