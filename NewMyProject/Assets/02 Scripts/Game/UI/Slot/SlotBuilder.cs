using MyUI.Interface;
using MyUI.Strategy.Layout;
using MyUI.Strategy.Spawn;
using MyUtil.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace MyUI
{
    public class SlotBuilder : MonoBehaviour
    {
        private IUISpawnStrategy _spawnStrategy;
        private IUILayoutStrategy _layoutStrategy;

        private UICreator _creator;

        private List<ObjectPoolType> _types = new List<ObjectPoolType>();

        [SerializeField] private Transform _parentTrans;

        private void Awake()
        {
            _types.Add(ObjectPoolType.Slot);
            _spawnStrategy = new PoolUISpawnStrategy();
            _layoutStrategy = new GridLayoutStrategy();

            _creator = GetComponent<UICreator>();
            _creator.Init(_layoutStrategy, _spawnStrategy);
        }

        private void Start()
        {
            _creator.CreateUI(_types, _parentTrans, 9, 6, 50, 50, 10);
        }
    }
}

