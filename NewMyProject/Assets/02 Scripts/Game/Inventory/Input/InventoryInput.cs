using UnityEngine;
using Manager.Input;
using MyUI.Animator.Interface;
using MyUI.Animator;
using MyUI.Animator.Enum;

namespace Game.Inventory.Input
{
    public class InventoryInput : MonoBehaviour
    {
        private bool _isOpen = false;

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
            if(_isOpen)
            {
                _isOpen = false;
                UIAnimatorEventManager.Play(UIAnimationType.FadeOut);
            }
            else
            {
                _isOpen = true;
                UIAnimatorEventManager.Play(UIAnimationType.FadeIn);
            }
        }
    }
}

