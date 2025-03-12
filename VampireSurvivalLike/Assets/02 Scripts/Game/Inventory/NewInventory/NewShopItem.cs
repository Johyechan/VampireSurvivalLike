using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewShopItem : DraggableItem
{
    [SerializeField] private ShopItemSO _so;

    private InventoryItemMakeHandle _invenItemMakeHandle;

    protected override void Awake()
    {
        base.Awake();

        _invenItemMakeHandle = GetComponent<InventoryItemMakeHandle>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        // 돈 지불
        // 돈 지불 불가 일 경우 안된다고 표시

        // 인벤토리 아이템 생성
        _invenItemMakeHandle.MakeInventoryItem(_so.type, UIManager.Instance.inventoryUIParent);
    }

    protected override void HandleDrop(PointerEventData eventData)
    {

    }
}
