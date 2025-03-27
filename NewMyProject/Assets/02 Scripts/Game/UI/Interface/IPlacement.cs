using MyUI.Item;
using MyUI.Slot;
using MyUI.Struct;
using UnityEngine;

namespace MyUI.Interface
{
    public interface IPlacement
    {
        public Vector2Int? CanPlace(InventorySlot slot, ItemShape shape);

        public void CalculatePlacePos(RectTransform rectTrans, InventorySlot slot, ItemShape shape, Vector2Int criteria);

        public bool Place(RectTransform itemRectTrans, InventorySlot slot, ItemShape shape);
    }
}

