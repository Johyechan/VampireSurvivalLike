using MyUtil;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager.Input
{
    public class InputManager : Singleton<InputManager>
    {
        public UIInput UIInputs { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            UIInputs = GetComponent<UIInput>();
        }
    }
}

