using Inventory;
using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Weapon;

namespace Player
{
    public class PlayerBackpack : MonoBehaviour
    {
        private int[,] _backpackArr = new int[9,6];
        public int[,] BackpackArr
        {
            get
            {
                return _backpackArr;
            }
            set
            {
                _backpackArr = value;
            }
        }

        public void GetBackpackWeapon()
        {
            Image[] images = UIManager.Instance.GetUIImages();
            int count = 0;
            for(int i = 0; i < images.Length; i++)
            {
                if (images[i].gameObject.name == "InventoryItem")
                {
                    count++;
                    if (transform.childCount < count)
                    {
                        InventoryItem item = images[i].GetComponent<InventoryItem>();
                        GameObject itemObj = ObjectPoolManager.Instance.GetObject(item.so.type, transform);
                    }
                }
            }

            if(count < transform.childCount)
            {
                for(int i = transform.childCount - 1; i >= count; i--)
                {
                    ObjectPoolManager.Instance.ReturnObject(transform.GetChild(i).GetComponent<WeaponBase>().type, transform.GetChild(i).gameObject);
                }
            }
        }

        public void CalculateWeaponPos(GameObject[] objs, float radius)
        {
            for(int i = 0; i < objs.Length; i++)
            {
                GameObject weapon = objs[i].gameObject;

                Vector3 pos = new Vector3(Mathf.Cos(Mathf.PI * 2 * i / objs.Length), Mathf.Sin(Mathf.PI * 2 * i / objs.Length)) * radius;
                weapon.transform.position = transform.position + pos;
                Vector3 rotation = Vector3.forward * 360 * i / objs.Length;
                weapon.transform.Rotate(rotation);
            }
        }
    }
}

