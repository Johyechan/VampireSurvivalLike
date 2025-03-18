using MyUtil.Pool;
using UnityEngine;

namespace MyUI.Interface
{
    public interface IUISpawnStrategy
    {
        public GameObject SpawnUI(ObjectPoolType type, Transform parent);
    }
}

