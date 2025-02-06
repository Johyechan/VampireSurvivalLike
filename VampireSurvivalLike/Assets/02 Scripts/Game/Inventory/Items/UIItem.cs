using Inventory;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

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

        protected virtual void Update()
        {

        }

        protected void UpdateFollowIconPosition(PointerEventData eventData, RectTransform rectTransform)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, eventData.position, _canvas.worldCamera, out Vector2 localPoint);

            if (rectTransform != null)
            {
                rectTransform.localPosition = localPoint;
            }

            
            // q�� ������ �������� 90�� ȸ�� e�� ������ ���������� 90�� ȸ��
            // �� + ���ִ� ������ ������ ���ظ� �˸� �ȴ�
            // ������ ã��
            // ���࿡ x�� y��� �߿��� ���̳ʽ� ���� �����ϸ� -���� ū �� - ���� ������
            // ���࿡ ���̳ʽ��� ���� 0�� �������� ������� -���� ū �� + ���� ���� �� 
            /*
             *  0��
                (0,0) (1,0)
                (0,1)
                (0,2)
                
                270(-90)��
                (0,0)				    (0,-1)              +    (0,1)
                (0,1) (1,1) (2,1)		(0,0) (1,0) (2,0)   +    (0,1) (0,1) (0,1)           
                
                180��
                      (1,0)		            (2,-2)          +           (-1,2)
                      (1,1)		            (2,-1)          +           (-1,2)
                (0,2) (1,2)		      (1,0) (2,0)	        +    (-1,2) (-1,2)
                
                90(-270)��
                (0,0) (1,0) (2,0)		(-2,0) (-1,0) (0,0)     +       (2,0) (2,0) (2,0)
                            (2,1)		              (0,1)     +                   (2,0)
                
                270(-90)��
                x' = y
                y' = -x
                
                180��
                x' = 2 * cx - x
                y' = 2 * cy - y
                
                90(-270)��
                x' = -y
                y' = x
            */
        }

        protected Vector2Int[] RotateItem(Vector2Int[] shape, bool right = true)
        {
            int xAdjust = 1;
            int yAdjust = 1;
            int temp = 0;

            Vector2Int bigest = Vector2Int.zero;
            Vector2Int smallest = Vector2Int.zero;

            if(right)
            {
                for(int i = 0; i < shape.Length; i++)
                {
                    temp = shape[i].x;
                    shape[i].x = -shape[i].y;
                    shape[i].y = temp;

                    if (xAdjust > 0)
                    {
                        xAdjust = CheckValueNeedAdjustX(shape[i]);
                    }
                    else if (xAdjust == 0)
                    {
                        if (shape[i].x < 0)
                        {
                            xAdjust = CheckValueNeedAdjustX(shape[i]);
                        }
                    }

                    if (yAdjust > 0)
                    {
                        yAdjust = CheckValueNeedAdjustY(shape[i]);
                    }
                    else if (yAdjust == 0)
                    {
                        if (shape[i].y < 0)
                        {
                            yAdjust = CheckValueNeedAdjustY(shape[i]);
                        }
                    }

                    bigest.x = CheckBigest(bigest.x, shape[i].x);
                    bigest.y = CheckBigest(bigest.y, shape[i].y);

                    smallest.x = CheckSmallest(smallest.x, shape[i].x);
                    smallest.y = CheckSmallest(smallest.y, shape[i].y);
                }

                if(xAdjust != 0 ||  yAdjust != 0)
                {
                    for (int i = 0; i < shape.Length; i++)
                    {
                        if(xAdjust != 0)
                        {
                            shape[i].x += Adjust(bigest.x, smallest.x, xAdjust);
                        }
                        if(yAdjust != 0)
                        {
                            shape[i].y += Adjust(bigest.y, smallest.y, yAdjust);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < shape.Length; i++)
                {
                    temp = shape[i].x;
                    shape[i].x = shape[i].y;
                    shape[i].y = -temp;

                    if (xAdjust > 0)
                    {
                        xAdjust = CheckValueNeedAdjustX(shape[i]);
                    }
                    else if(xAdjust == 0)
                    {
                        if (shape[i].x < 0)
                        {
                            xAdjust = CheckValueNeedAdjustX(shape[i]);
                        }
                    }

                    if (yAdjust > 0)
                    {
                        yAdjust = CheckValueNeedAdjustY(shape[i]);
                    }
                    else if(yAdjust == 0)
                    {
                        if (shape[i].y < 0)
                        {
                            yAdjust = CheckValueNeedAdjustY(shape[i]);
                        }
                    }

                    bigest.x = CheckBigest(bigest.x, shape[i].x);
                    bigest.y = CheckBigest(bigest.y, shape[i].y);

                    smallest.x = CheckSmallest(smallest.x, shape[i].x);
                    smallest.y = CheckSmallest(smallest.y, shape[i].y);
                }

                if (xAdjust != 0 || yAdjust != 0)
                {
                    for (int i = 0; i < shape.Length; i++)
                    {
                        if (xAdjust != 0)
                        {
                            shape[i].x += Adjust(bigest.x, smallest.x, xAdjust);
                        }
                        if (yAdjust != 0)
                        {
                            shape[i].y += Adjust(bigest.y, smallest.y, yAdjust);
                        }
                    }
                }
            }

            return shape;
        }

        private int CheckBigest(int value1, int value2)
        {
            if(value1 < value2)
            {
                return value2;
            }
            else
            {
                return value1;
            }
        }

        private int CheckSmallest(int value1, int value2)
        {
            if(value1 > value2)
            {
                return value2;
            }
            else
            {
                return value1;
            }
        }

        private int Adjust(int bigest, int smallest, int isMinus)
        {
            if(isMinus < 0)
            {
                return -bigest - smallest;
            }
            else
            {
                return -bigest + smallest;
            }
        }

        private int CheckValueNeedAdjustX(Vector2Int vec)
        {
            if (vec.x < 0)
            {
                return -1;
            }
            else if (vec.x == 0)
            {
                return 0;
            }

            return 1;
        }

        private int CheckValueNeedAdjustY(Vector2Int vec)
        {
            if (vec.y < 0)
            {
                return -1;
            }
            else if(vec.y == 0)
            {
                return 0;
            }

            return 1;
        }

        protected GameObject UIMousePos(string exceptionName = null)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(pointer, results);

            foreach(RaycastResult result in results)
            {
                if(exceptionName != null)
                {
                    if (result.gameObject.CompareTag(exceptionName))
                    {
                        return result.gameObject;
                    }
                }

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

                    inventoryItem.Slots.Add(new Vector2Int(targetX, targetY));
                }

                // UI ��ġ ���
                CalculateUIPos(item, slot, shape, validOrigin.Value);
                // ���⼭ ���� uiImage�� alphaTarget�� �����Ǵ� UI �߰�
                inventoryItem.IsShop = false;
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

