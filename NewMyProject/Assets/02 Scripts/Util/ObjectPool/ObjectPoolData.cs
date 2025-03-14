using System;
using UnityEngine;

namespace MyUtil.Pool
{
    [Serializable]
    public class ObjectPoolData
    {
        public ObjectPoolType prefabType;
        public GameObject prefabObj;
        public int prefabCount;
    }
}

