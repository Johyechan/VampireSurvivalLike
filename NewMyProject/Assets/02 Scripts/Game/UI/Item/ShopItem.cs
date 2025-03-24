using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.Item
{
    public class ShopItem : UIItem
    {
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);

            // new Slot.InventorySlot 드래그 쪽에서 InventorySlot 오브젝트 가져와서 리턴하고 그거 쓰면 될 듯
            if(!_placement.Place(_rectTrans, new Slot.InventorySlot(), _so.shape))
            {
                Debug.Log("배치 불가");
                // 돈 돌려받기
            }
        }
    }
}

