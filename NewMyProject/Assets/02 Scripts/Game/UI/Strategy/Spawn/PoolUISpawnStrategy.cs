using MyUI.Interface;
using MyUtil.Pool;
using UnityEngine;

namespace MyUI.Strategy.Spawn
{
    public class PoolUISpawnStrategy : IUISpawnStrategy
    {
        public GameObject SpawnUI(ObjectPoolType type, Transform parent)
        {
            return ObjectPoolManager.Instance.GetObject(type, parent);
        }
    }
}

