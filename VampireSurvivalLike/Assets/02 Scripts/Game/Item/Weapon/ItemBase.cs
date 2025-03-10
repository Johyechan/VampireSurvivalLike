using Manager;
using MySO;
using MyStat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ItemBase : MonoBehaviour
    {
        public ItemSO so;

        protected virtual void Awake()
        {
            gameObject.name += GameManager.Instance.itemNum++;
        }
    }
}

