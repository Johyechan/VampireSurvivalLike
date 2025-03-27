using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtil.Pool
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        [SerializeField] private List<ObjectPoolData> _objectPoolDataList = new List<ObjectPoolData>();

        private Dictionary<ObjectPoolType, ObjectPoolData> _objectPoolMap = new Dictionary<ObjectPoolType, ObjectPoolData>();
        private Dictionary<ObjectPoolType, Queue<GameObject>> _objectPool = new Dictionary<ObjectPoolType, Queue<GameObject>>();

        protected override void Awake()
        {
            base.Awake();

            Init();
        }

        private void Init()
        {
            foreach(var data in _objectPoolDataList)
            {
                _objectPoolMap.Add(data.prefabType, data);
            }

            foreach(var data in _objectPoolMap)
            {
                _objectPool.Add(data.Key, new Queue<GameObject>());

                ObjectPoolData poolData = data.Value;

                for(int i = 0; i < poolData.prefabCount; i++)
                {
                    GameObject obj = CreateNewObj(data.Key);
                    _objectPool[data.Key].Enqueue(obj);
                }
            }
        }

        private GameObject CreateNewObj(ObjectPoolType type)
        {
            GameObject newObj = Instantiate(_objectPoolMap[type].prefabObj, transform);
            newObj.SetActive(false);

            return newObj;
        }

        public GameObject GetObject(ObjectPoolType type, Transform trans = null)
        {
            if (_objectPool[type].Count > 0)
            {
                GameObject obj = _objectPool[type].Dequeue();
                obj.SetActive(true);
                obj.transform.SetParent(trans);
                return obj;
            }
            else
            {
                GameObject newObj = CreateNewObj(type);
                newObj.SetActive(true);
                newObj.transform.SetParent(trans);
                return newObj;
            }
        }

        public void ReturnObj(ObjectPoolType type, GameObject obj)
        {
            obj.transform.position = Vector2.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            _objectPool[type].Enqueue(obj);
        }
    }
}

