using Manager.Input;
using MyUI.Animator;
using MyUI.Animator.Enum;

namespace Game.Inventory.Input
{
    public class InventoryInput : EventSubscriber
    {
        private bool _isOpen = false;

        protected override void SubscribeEvents()
        {
            InputManager.Instance.OnInventoryToggle += ToggleInventory;
        }

        protected override void UnsubscribeEvents()
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

