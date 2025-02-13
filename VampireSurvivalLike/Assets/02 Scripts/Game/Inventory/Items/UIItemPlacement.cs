using UnityEngine;

namespace Inventory
{
    public class UIItemPlacement : MonoBehaviour
    {
        public Vector2Int? CanPlaceItem(InventorySlot slot, Vector2Int[] shape)
        {
            // ��� �������� ���� ��ġ ���� ���� Ȯ��
            foreach (Vector2Int origin in shape)
            {
                bool canPlace = true;

                foreach (Vector2Int offset in shape)
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

        private void CalculateUIPos(GameObject item, InventorySlot slot, Vector2Int[] shape, Vector2Int validOrigin)
        {
            // ��� ���� ��ġ�� ����� ���ϱ� ���� ����
            Vector3 sumPosition = Vector3.zero;

            foreach (Vector2Int vec2int in shape)
            {
                int targetX = slot.X + vec2int.x - validOrigin.x;
                int targetY = slot.Y + vec2int.y - validOrigin.y;

                InventorySlot targetSlot = InventoryManager.Instance.Grid[targetX, targetY];
                RectTransform rectTransform = targetSlot.GetComponent<RectTransform>();

                // ��ġ �ջ�
                sumPosition += rectTransform.position;
            }

            // ��� ��ġ ���
            Vector3 averagePosition = sumPosition / shape.Length;

            // ������ ��ġ ����
            RectTransform itemTransform = item.GetComponent<RectTransform>();
            itemTransform.position = averagePosition;
        }

        public void PlaceItem(GameObject item, InventorySlot slot, Vector2Int[] shape, InventoryItem inventoryItem)
        {
            // ��ġ ������ ������ ã��
            Vector2Int? validOrigin = CanPlaceItem(slot, shape);

            // ��ġ ������ �������� �ִٸ�
            if (validOrigin.HasValue)
            {
                // �ش� ���������� ���� ���� ���¸� ������Ʈ
                foreach (Vector2Int offset in shape)
                {
                    int targetX = slot.X + offset.x - validOrigin.Value.x;
                    int targetY = slot.Y + offset.y - validOrigin.Value.y;

                    InventoryManager.Instance.Grid[targetX, targetY].IsOccupied = true;

                    inventoryItem.Slots.Add(new Vector2Int(targetX, targetY));
                }

                // UI ��ġ ���
                CalculateUIPos(item, slot, shape, validOrigin.Value);
                // ���⼭ ���� uiImage�� alphaTarget�� �����Ǵ� UI �߰�
                inventoryItem.IsShop = false;
            }
        }
    }
}

