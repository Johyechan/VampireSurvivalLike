using Manager.Inventory;
using MyUI.Interface;
using MyUI.Slot;
using MyUI.Struct;
using UnityEngine;

namespace MyUI.Item.HandleSystem
{
    public class PlacementHandle : IPlacement
    {
        public void CalculatePlacePos(RectTransform rectTrans, InventorySlot slot, ItemShape shape, Vector2Int criteria)
        {
            // ��� ���� ��ġ�� ����� ���ϱ� ���� ����
            Vector3 sumPosition = Vector3.zero;

            foreach (Vector2Int vec2int in shape.shape)
            {
                int targetX = slot.X + vec2int.x - criteria.x;
                int targetY = slot.Y + vec2int.y - criteria.y;

                InventorySlot targetSlot = InventoryManager.Instance.Grid[targetX, targetY];
                RectTransform rectTransform = targetSlot.GetComponent<RectTransform>();

                // ��ġ �ջ�
                sumPosition += rectTransform.position;
            }

            // ��� ��ġ ���
            Vector3 averagePosition = sumPosition / shape.shape.Length;

            // ������ ��ġ ����
            RectTransform itemTransform = rectTrans.GetComponent<RectTransform>();
            itemTransform.position = averagePosition;
        }

        public Vector2Int? CanPlace(InventorySlot slot, ItemShape shape)
        {
            // ��� �������� ���� ��ġ ���� ���� Ȯ��
            foreach (Vector2Int origin in shape.shape)
            {
                bool canPlace = true;

                foreach (Vector2Int offset in shape.shape)
                {
                    int checkX = slot.X + offset.x - origin.x;
                    int checkY = slot.Y + offset.y - origin.y;

                    // �׸��� ������ ����ų� �̹� ������ ������ ������ ��ġ �Ұ�
                    if (checkX < 0 || checkY < 0 ||
                        checkX >= InventoryManager.Instance.Grid.GetLength(0) ||
                        checkY >= InventoryManager.Instance.Grid.GetLength(1) ||
                        InventoryManager.Instance.Grid[checkX, checkY].IsOccupied ||
                        !InventoryManager.Instance.Grid[checkX, checkY].gameObject.activeSelf)
                    {
                        canPlace = false;
                        break;
                    }
                }

                // ��ġ�� �����ϸ� ������ ��ȯ
                if (canPlace)
                {
                    return origin;  // �� �������� ��ġ �������� ��ȯ
                }
            }

            // ��ġ�� �� �ִ� �������� ���ٸ� null ��ȯ
            return null;
        }

        public bool Place(RectTransform itemRectTrans, InventorySlot slot, ItemShape shape, ShopAndInventoryItem item = null)
        {
            // ��ġ ������ ������ ã��
            Vector2Int? criteria = CanPlace(slot, shape);
            
            // ��ġ ������ �������� �ִٸ�
            if (criteria.HasValue)
            {
                // �ش� ���������� ���� ���� ���¸� ������Ʈ
                foreach (Vector2Int offset in shape.shape)
                {
                    int targetX = slot.X + offset.x - criteria.Value.x;
                    int targetY = slot.Y + offset.y - criteria.Value.y;

                    InventoryManager.Instance.Grid[targetX, targetY].IsOccupied = true;
                    item.SaveGridIndexs.Add(new Vector2Int(targetX, targetY));
                }

                // UI ��ġ ���
                CalculatePlacePos(itemRectTrans, slot, shape, criteria.Value);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}