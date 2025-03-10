using Inventory;
using Item;
using Manager;
using Pool;
using UnityEngine;

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
            int count = 0;
            foreach(var uis in UIManager.Instance.UIs)
            {
                if(uis.Key.Contains("InventoryItem"))
                {
                    if(!uis.Value.transform.parent.gameObject.CompareTag("SaveBox") && !uis.Value.gameObject.CompareTag("OnlyInven"))
                    {
                        count++;
                        // 여기서 문제가 있는 거 같음 분명 InventoryItem에서는 Type이 정확한데 여기서 Type 달라짐
                        // 가설 1: 다 못 읽고 이전 마지막 InventoryItem까지만 읽고 끝나는 경우일 것이다
                        if (transform.childCount < count)
                        {
                            InventoryItem item = uis.Value.gameObject.GetComponent<InventoryItem>();
                            Debug.Log(item.so.type);
                            GameObject itemObj = ObjectPoolManager.Instance.GetObject(item.so.type, transform);
                        }
                    }
                }
            }

            if(count < transform.childCount)
            {
                for(int i = transform.childCount - 1; i >= count; i--)
                {
                    ObjectPoolManager.Instance.ReturnObject(transform.GetChild(i).GetComponent<ItemBase>().so.objType, transform.GetChild(i).gameObject);
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

