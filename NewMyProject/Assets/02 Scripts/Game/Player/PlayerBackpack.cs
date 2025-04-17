using Item;
using Item.Weapon;
using MyUtil.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Backpack
{
    public class PlayerBackpack : MonoBehaviour
    {
        public BackpackSO backpackSO;

        private List<string> items = new List<string>();

        [SerializeField] private Transform _inventoryItemParent;
        [SerializeField] private Transform _weaponItemParent;

        private bool HasItem(string itemName)
        {
            if(items.Contains(itemName))
            {
                return true;
            }

            return false;
        }

        public void ClearItem()
        {
            items.Clear();
            for(int i = _weaponItemParent.childCount - 1; i >= 0; i--)
            {
                GameObject obj = _weaponItemParent.GetChild(i).gameObject;
                if (obj.TryGetComponent<ItemBase>(out var item))
                {
                    Debug.Log(item.itemSO.objType);
                    Debug.Log(obj);
                    ObjectPoolManager.Instance.ReturnObj(item.itemSO.objType, obj);
                }
            }

            for(int i = _inventoryItemParent.childCount - 1;i >= 0; i--)
            {
                GameObject obj = _inventoryItemParent.GetChild(i).gameObject;
                if (obj.TryGetComponent<ItemBase>(out var item))
                {
                    ObjectPoolManager.Instance.ReturnObj(item.itemSO.objType, obj);
                }
            }
        }

        public void AddItem(string itemName, ObjectPoolType type)
        {
            if(!HasItem(itemName))
            {
                items.Add(itemName);
                GameObject item = ObjectPoolManager.Instance.GetObject(type);
                if (item.TryGetComponent<WeaponItem>(out var weapon))
                {
                    weapon.transform.SetParent(_weaponItemParent);
                }
                else
                {
                    item.transform.SetParent(_inventoryItemParent);
                }
            }
        }

        public void WeaponPositionSet()
        {
            int count = _weaponItemParent.childCount;

            float distance = 1.5f;

            for(int i = 0; i < count; i++)
            {
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / count), Mathf.Sin(Mathf.PI * 2 * i / count));
                _weaponItemParent.GetChild(i).transform.position = dir * distance;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                _weaponItemParent.GetChild(i).transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }
    }
}

