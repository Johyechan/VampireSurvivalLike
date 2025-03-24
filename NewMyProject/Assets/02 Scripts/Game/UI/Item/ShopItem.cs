using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.Item
{
    public class ShopItem : UIItem
    {
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);

            // new Slot.InventorySlot �巡�� �ʿ��� InventorySlot ������Ʈ �����ͼ� �����ϰ� �װ� ���� �� ��
            if(!_placement.Place(_rectTrans, new Slot.InventorySlot(), _so.shape))
            {
                Debug.Log("��ġ �Ұ�");
                // �� �����ޱ�
            }
        }
    }
}

