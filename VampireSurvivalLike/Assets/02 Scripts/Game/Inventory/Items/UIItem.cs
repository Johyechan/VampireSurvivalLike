using Inventory;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class UIItem : MonoBehaviour
    {
        protected Canvas _canvas;

        protected GraphicRaycaster _raycaster;

        protected Vector2Int[] _shape;

        protected virtual void Awake()
        {
            _canvas = FindObjectOfType<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
        }

        protected void UpdateFollowIconPosition(PointerEventData eventData, RectTransform rectTransform)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, eventData.position, _canvas.worldCamera, out Vector2 localPoint);

            rectTransform.localPosition = localPoint;
        }

        protected GameObject UIMousePos()
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(pointer, results);

            foreach(RaycastResult result in results)
            {
                InventorySlot slot = result.gameObject.GetComponent<InventorySlot>();
                if(slot != null)
                {
                    return result.gameObject;
                }
            }

            return null;
        }

        private Vector2Int? CanPlaceItem(InventorySlot slot, Vector2Int[] shape)
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
                        InventoryManager.Instance.Grid[checkX, checkY].IsOccupied)
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

        public bool PlaceItem(GameObject item, InventorySlot slot, Vector2Int[] shape, InventoryItem inventoryItem)
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

                    Debug.Log(inventoryItem.Slots);
                    inventoryItem.Slots.Add(new Vector2Int(targetX, targetY));
                }

                // UI ��ġ ���
                CalculateUIPos(item, slot, shape, validOrigin.Value);
                return true;
            }

            // ��ġ �Ұ����ϸ� false ��ȯ
            return false;
        }

        public void RemoveItem(List<Vector2Int> slots)
        {
            foreach(Vector2Int slot in slots)
            {
                InventoryManager.Instance.Grid[slot.x, slot.y].IsOccupied = false;
            }
        }
    }
}

