using MyUtil;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager.Input
{
    public class InputManager : Singleton<InputManager>
    {
        [SerializeField] private InputActionAsset _uiInputAsset;

        private InputAction _toggleInventoryAction;

        public event Action OnInventoryToggle;

        protected override void Awake()
        {
            base.Awake();

            _toggleInventoryAction = _uiInputAsset.FindActionMap("Inventory").FindAction("InventoryToggle");
        }

        private void OnEnable()
        {
            _toggleInventoryAction.Enable();
            _toggleInventoryAction.performed += _ => OnInventoryToggle?.Invoke();
        }

        private void OnDisable()
        {
            _toggleInventoryAction.Disable();
        }
    }
}

