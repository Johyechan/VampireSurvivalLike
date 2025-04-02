using MyUtil.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Backpack
{
    public class PlayerBackpack : MonoBehaviour
    {
        public BackpackSO backpackSO;

        private List<string> weapons = new List<string>();

        private bool HasItem(string itemName)
        {
            if(weapons.Contains(itemName))
            {
                return true;
            }

            return false;
        }

        public void AddItem(string itemName, ObjectPoolType type)
        {
            if(!HasItem(itemName))
            {
                weapons.Add(itemName);
                GameObject weapon = ObjectPoolManager.Instance.GetObject(type);
                weapon.transform.SetParent(transform);
            }
        }

        public void WeaponPositionSet()
        {
            int count = transform.childCount;

            float distance = 1.5f;

            for(int i = 0; i < count; i++)
            {
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / count), Mathf.Sin(Mathf.PI * 2 * i / count));
                transform.GetChild(i).transform.position = dir * distance;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.GetChild(i).transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }
    }
}

