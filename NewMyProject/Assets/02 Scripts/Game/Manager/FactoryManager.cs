using MyFactory;
using MyFactory.Enum;
using MyFactory.Interface;
using MyUtil;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class FactoryManager : Singleton<FactoryManager>
    {
        private Dictionary <FactoryType, IFactory> _factories = new Dictionary <FactoryType, IFactory>();

        protected override void Awake()
        {
            base.Awake();

            AddFactory(FactoryType.UIItem, new UIItemFactory());
        }

        public void AddFactory(FactoryType type, IFactory factory)
        {
            _factories.Add(type, factory);
        }

        public T GetFactory<T>(FactoryType type) where T : class, IFactory
        {
            return _factories[type] as T;
        }
    }
}

