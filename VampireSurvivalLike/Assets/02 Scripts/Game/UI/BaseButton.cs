using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUI
{
    public abstract class BaseButton : MonoBehaviour
    {
        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }

        public abstract void OnCliked();
    }
}

