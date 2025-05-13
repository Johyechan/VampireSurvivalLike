using Manager;
using Manager.Input;
using Manager.Inventory;
using Manager.UI;
using MyUI.Animator;
using MyUI.Animator.Enum;
using MyUI.Interface;
using MyUI.Item.HandleSystem;
using UnityEngine;

namespace Game.Inventory.Input
{
    public class InventoryInput : EventSubscriber
    {
        private IRotation _rotation;

        private void Awake()
        {
            _rotation = new RotationHandle();
        }

        protected override void SubscribeEvents()
        {
            InputManager.Instance.UIInputs.OnInventoryToggle += ToggleInventory;
            InputManager.Instance.UIInputs.OnUIItemRotate += ItemRotate;
        }

        protected override void UnsubscribeEvents()
        {
            if(InputManager.Instance == null || InputManager.Instance.UIInputs == null)
            {
                return;
            }

            InputManager.Instance.UIInputs.OnInventoryToggle -= ToggleInventory;
            InputManager.Instance.UIInputs.OnUIItemRotate -= ItemRotate;
        }

        private void ToggleInventory()
        {
            if(GameManager.Instance.GameOver)
            {
                return;
            }

            if(Time.timeScale < 1)
            {
                UIAnimatorEventManager.Play(UIAnimationType.FadeOut);
            }
            else
            {
                Time.timeScale = 0;
                UIAnimatorEventManager.Play(UIAnimationType.FadeIn);
            }
        }

        private void ItemRotate(bool isRight)
        {
            if(isRight)
            {
                UIItemManager.Instance.CurrentUIItem.gameObject.transform.Rotate(0, 0, -90);
            }
            else
            {
                UIItemManager.Instance.CurrentUIItem.gameObject.transform.Rotate(0, 0, 90);
            }
            
            UIItemManager.Instance.CurrentUIItem.shape = _rotation.Rotate(UIItemManager.Instance.CurrentUIItem.shape, isRight);
        }
    }
}

