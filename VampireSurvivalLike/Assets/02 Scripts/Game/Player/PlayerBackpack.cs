using Inventory;
using Item;
using Manager;
using Pool;
using System.Collections.Generic;
using System.Linq;
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

        private Dictionary<string, GameObject> _backpackWeaponMap = new Dictionary<string, GameObject>();
        private Dictionary<string, bool> _callCheckMap = new Dictionary<string, bool>();

        private void Awake()
        {
            _backpackWeaponMap.Clear();
            _callCheckMap.Clear();
        }

        public void GetBackpackWeapon()
        {
            // 불렸는지 체크하는 딕셔너리를 전부 안 불림 상태 즉 false로 초기화
            foreach (var check in _callCheckMap.ToList())
            {
                _callCheckMap[check.Key] = false;
            }

            foreach(var uis in UIManager.Instance.UIs)
            {
                if(uis.Key.Contains("InventoryItem"))
                {
                    if(!uis.Value.transform.parent.gameObject.CompareTag("SaveBox") && !uis.Value.gameObject.CompareTag("OnlyInven"))
                    {
                        if(!_backpackWeaponMap.ContainsKey(uis.Value.gameObject.name))
                        {
                            InventoryItem item = uis.Value.gameObject.GetComponent<InventoryItem>();
                            GameObject itemObj = ObjectPoolManager.Instance.GetObject(item.so.type, transform);
                            _backpackWeaponMap.Add(item.gameObject.name, itemObj);
                            _callCheckMap.Add(item.gameObject.name, true);
                        }
                        else
                        {
                            _callCheckMap[uis.Value.gameObject.name] = true;
                        }
                    }
                }
            }

            foreach(var check in _callCheckMap.ToList())
            {
                if (!_callCheckMap[check.Key])
                {
                    ItemBase item = _backpackWeaponMap[check.Key].GetComponent(typeof(ItemBase)) as ItemBase;
                    if (item != null)
                    {
                        ObjectPoolManager.Instance.ReturnObject(item.so.objType, item.gameObject);
                    }
                    _callCheckMap.Remove(check.Key);
                    _backpackWeaponMap.Remove(check.Key);
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

