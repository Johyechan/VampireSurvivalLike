using Manager.Input;
using System;
using UnityEngine;

public class PlayerEventSubscriber : EventSubscriber
{
    public Action OnAddItem;

    protected override void SubscribeEvents()
    {
        InputManager.Instance.UIInputs.OnInventoryToggle += ToggleInventory;
    }

    protected override void UnsubscribeEvents()
    {
        if(InputManager.Instance == null || InputManager.Instance.UIInputs == null)
        {
            return;
        }

        InputManager.Instance.UIInputs.OnInventoryToggle -= ToggleInventory;
    }

    private void ToggleInventory()
    {
        OnAddItem?.Invoke();
    }
}
