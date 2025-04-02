using Manager;
using Manager.Inventory;
using Player.Backpack;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerSO playerSO;

        private PlayerBackpack _backpack;

        private PlayerEventSubscriber _eventSubscriber;

        private void Awake()
        {
            _backpack = GetComponent<PlayerBackpack>();
            _eventSubscriber = GetComponent<PlayerEventSubscriber>();
        }

        private void OnEnable()
        {
            _eventSubscriber.OnAddItem += AddItem;
        }

        private void OnDisable()
        {
            _eventSubscriber.OnAddItem -= AddItem;
        }

        private void AddItem()
        {
            foreach (var item in InventoryManager.Instance.Items)
            {
                _backpack.AddItem(item.Key, item.Value);
            }

            _backpack.WeaponPositionSet();
        }
    }
}

