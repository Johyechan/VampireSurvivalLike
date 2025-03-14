using UnityEngine;
using Manager.Input;

namespace Game.Inventory.Input
{
    public class InventoryInput : MonoBehaviour
    {
        private void OnEnable()
        {
            InputManager.Instance.OnInventoryToggle += ToggleInventory;
        }

        private void OnDisable()
        {
            InputManager.Instance.OnInventoryToggle -= ToggleInventory;
        }

        private void ToggleInventory()
        {
            // �κ��丮 ����
        }
    }
}

