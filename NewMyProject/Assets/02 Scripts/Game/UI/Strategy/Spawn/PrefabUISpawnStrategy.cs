using MyUI.Interface;
using MyUtil.Pool;
using UnityEngine;

namespace MyUI.Strategy.Spawn
{
    public class PrefabUISpawnStrategy : IUISpawnStrategy
    {
        private GameObject _prefab;

        public PrefabUISpawnStrategy(GameObject prefab)
        {
            _prefab = prefab;
        }

        public GameObject SpawnUI(ObjectPoolType type, Transform parent)
        {
            return GameObject.Instantiate(_prefab, parent);
        }
    }
}

