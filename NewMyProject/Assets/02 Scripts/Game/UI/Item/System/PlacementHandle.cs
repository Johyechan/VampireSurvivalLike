using Manager.Inventory;
using MyUI.Interface;
using MyUI.Slot;
using MyUI.Struct;
using System.Collections.Generic;
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
            Debug.Log(slot);
            Debug.Log(shape);
            Debug.Log(shape.shape); // �̰� ��
            // ��� �������� ���� ��ġ ���� ���� Ȯ��
            foreach (Vector2Int origin in shape.shape)
            {
                Debug.Log("dd");
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

        public bool Place(RectTransform itemRectTrans, InventorySlot slot, ItemShape shape)
        {
            // ��ġ ������ ������ ã��
            Vector2Int? criteria = CanPlace(slot, shape);
            
            // ��ġ ������ �������� �ִٸ�
            if (criteria.HasValue)
            {
                foreach (var item in InventoryManager.Instance.ItemGrid)
                {
                    if (item.Key == itemRectTrans.gameObject.name)
                    {
                        for (int i = 0; i < item.Value.Count; i++)
                        {
                            item.Value.Dequeue();
                        }
                    }
                }

                // �ش� ���������� ���� ���� ���¸� ������Ʈ
                foreach (Vector2Int offset in shape.shape)
                {
                    int targetX = slot.X + offset.x - criteria.Value.x;
                    int targetY = slot.Y + offset.y - criteria.Value.y;

                    if(!InventoryManager.Instance.ItemGrid.ContainsKey(itemRectTrans.gameObject.name))
                    {
                        InventoryManager.Instance.ItemGrid.Add(itemRectTrans.gameObject.name, new Queue<Vector2Int>());
                        InventoryManager.Instance.ItemGrid[itemRectTrans.gameObject.name].Enqueue(new Vector2Int(targetX, targetY));
                    }
                    else
                    {
                        InventoryManager.Instance.ItemGrid[itemRectTrans.gameObject.name].Enqueue(new Vector2Int(targetX, targetY));
                    }
                    InventoryManager.Instance.Grid[targetX, targetY].IsOccupied = true;
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