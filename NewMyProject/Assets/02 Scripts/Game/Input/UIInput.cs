using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInput : MonoBehaviour
{
    [SerializeField] private InputActionAsset _uiInputAsset;

    private InputAction _toggleInventoryAction;
    private InputAction _uiItemRightRotateAction;
    private InputAction _uiItemLeftRotateAction;

    public event Action OnInventoryToggle;
    public event Action<bool> OnUIItemRotate;

    private void Awake()
    {
        _toggleInventoryAction = _uiInputAsset.FindActionMap("Inventory").FindAction("InventoryToggle");
        _uiItemRightRotateAction = _uiInputAsset.FindActionMap("Inventory").FindAction("UIItemRightRotate");
        _uiItemLeftRotateAction = _uiInputAsset.FindActionMap("Inventory").FindAction("UIItemLeftRotate");
    }

    private void OnEnable()
    {
        _uiInputAsset.Enable();
        _toggleInventoryAction.performed += _ => OnInventoryToggle?.Invoke();
        _uiItemRightRotateAction.performed += _ => OnUIItemRotate?.Invoke(true);
        _uiItemLeftRotateAction.performed += _ => OnUIItemRotate?.Invoke(false);
    }

    private void OnDisable()
    {
        _uiInputAsset.Disable();
    }
}
