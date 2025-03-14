using Inventory;
using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewShopItem : DraggableItem
{
    [SerializeField] private ShopItemSO _so;

    private InventoryItemMakeHandle _invenItemMakeHandle;

    private GameObject _followInvenItem;

    protected override void Awake()
    {
        base.Awake();

        _invenItemMakeHandle = GetComponent<InventoryItemMakeHandle>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ChangeUIAlpha(false, 0.1f);

        GameEventManager.OnMoneyUseEvent.EventCall(-_so.price);

        _followInvenItem = _invenItemMakeHandle.MakeInventoryItem(_so.InventoryType, UIManager.Instance.inventoryUIParent);
    }

    protected override void HandleDrop(PointerEventData eventData)
    {
        
    }

    private void ChangeUIAlpha(bool isAppear, float delay)
    {
        UIManager.Instance.UIs[gameObject.name].ChangeAlpha(isAppear, delay);
        UIManager.Instance.UIs[transform.GetChild(0).name].ChangeAlpha(isAppear, delay);
    }
}
