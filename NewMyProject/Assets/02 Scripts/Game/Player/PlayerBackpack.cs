using MyUtil.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Backpack
{
    public class PlayerBackpack : MonoBehaviour
    {
        public BackpackSO backpackSO;

        private Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();

        private bool HasItem(string itemName)
        {
            if(weapons.ContainsKey(itemName))
            {
                return true;
            }

            return false;
        }

        public void AddItem(GameObject item, ObjectPoolType type)
        {
            if(!HasItem(item.name))
            {
                weapons.Add(item.name, item);
                GameObject weapon = ObjectPoolManager.Instance.GetObject(type);
                weapon.transform.SetParent(transform);
            }
        }
    }
}

