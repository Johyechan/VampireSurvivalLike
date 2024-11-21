using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace Pool
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        [SerializeField] private List<ObjectPoolData> _objectPoolDatas = new List<ObjectPoolData>();

        private Dictionary<ObjectPoolType, ObjectPoolData> _objectPoolDataMap = new Dictionary<ObjectPoolType, ObjectPoolData>();
        private Dictionary<ObjectPoolType, Queue<GameObject>> _pool = new Dictionary<ObjectPoolType, Queue<GameObject>>();

        protected override void Awake()
        {
            base.Awake();

            Init();
        }

        private void Init()
        {
            foreach(var data in _objectPoolDatas)
            {
                _objectPoolDataMap.Add(data.type, data);
            }

            foreach(var poolData in _objectPoolDataMap)
            {
                _pool.Add(poolData.Key, new Queue<GameObject>());
                var objectPoolData = poolData.Value;

                for(int i = 0; i < objectPoolData.prefabCount; i++)
                {
                    var poolObject = CreateNewObject(poolData.Key);
                    _pool[poolData.Key].Enqueue(poolObject);
                }
            }
        }

        private GameObject CreateNewObject(ObjectPoolType type)
        {
            var newObj = Instantiate(_objectPoolDataMap[type].prefab, transform);
            newObj.SetActive(false);

            return newObj;
        }

        public GameObject GetObject(ObjectPoolType type, Transform trans = null)
        {
            if (_pool[type].Count > 0)
            {
                var obj = _pool[type].Dequeue();

                if(trans != null)
                {
                    obj.transform.SetParent(trans);
                }
                obj.SetActive(true);
                return obj;
            }
            else
            {
                var newObj = CreateNewObject(type);
                if(trans != null)
                {
                    newObj.transform.SetParent(trans);
                }
                newObj.SetActive(true);
                return newObj;
            }
        }

        public void ReturnObject(ObjectPoolType type, GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            _pool[type].Enqueue(obj);
        }
    }
}

