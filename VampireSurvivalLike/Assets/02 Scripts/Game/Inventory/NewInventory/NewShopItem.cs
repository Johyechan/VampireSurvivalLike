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

        // �� ���� ���θ� �˾ƾ� ��
        GameEventManager.OnMoneyUseEvent.EventCall(-_so.price);

        // �κ��丮 ������ ����
        _invenItemMakeHandle.MakeInventoryItem(_so.type, UIManager.Instance.inventoryUIParent);
    }

    protected override void HandleDrop(PointerEventData eventData)
    {

    }
}
