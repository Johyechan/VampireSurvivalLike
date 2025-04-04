using MyUtil;
using System;
using UnityEngine;

namespace Manager.UI
{
    public class UIManager : Singleton<UIManager>
    {
        public GameObject shopItemParent;

        public Action OnRefillItems;

        public void Refill()
        {
            OnRefillItems?.Invoke();
        }
    }
}

