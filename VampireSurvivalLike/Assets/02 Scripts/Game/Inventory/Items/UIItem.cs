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

            
            // q를 누르면 왼쪽으로 90도 회전 e를 누르면 오른쪽으로 90도 회전
            // 저 + 해주는 값들이 나오는 기준만 알면 된다
            // 보정값 찾기
            // 만약에 x나 y축들 중에서 마이너스 값이 존재하면 -가장 큰 값 - 가장 작은값
            // 만약에 마이너스가 없고 0이 존재하지 않을경우 -가장 큰 값 + 가장 작은 값 
            /*
             *  0도
                (0,0) (1,0)
                (0,1)
                (0,2)
                
                270(-90)도
                (0,0)				    (0,-1)              +    (0,1)
                (0,1) (1,1) (2,1)		(0,0) (1,0) (2,0)   +    (0,1) (0,1) (0,1)           
                
                180도
                      (1,0)		            (2,-2)          +           (-1,2)
                      (1,1)		            (2,-1)          +           (-1,2)
                (0,2) (1,2)		      (1,0) (2,0)	        +    (-1,2) (-1,2)
                
                90(-270)도
                (0,0) (1,0) (2,0)		(-2,0) (-1,0) (0,0)     +       (2,0) (2,0) (2,0)
                            (2,1)		              (0,1)     +                   (2,0)
                
                270(-90)도
                x' = y
                y' = -x
                
                180도
                x' = 2 * cx - x
                y' = 2 * cy - y
                
                90(-270)도
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
            // 모든 기준점에 대해 배치 가능 여부 확인
            foreach (Vector2Int origin in shape)
            {
                bool canPlace = true;

                foreach (Vector2Int offset in shape)
                {
                    int checkX = slot.X + offset.x - origin.x;
                    int checkY = slot.Y + offset.y - origin.y;

                    // 그리드 범위를 벗어나거나 이미 점유된 슬롯이 있으면 배치 불가
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

                // 배치가 가능하면 기준점 반환
                if (canPlace)
                {
                    return origin;  // 이 기준점에 배치 가능함을 반환
                }
            }

            // 배치할 수 있는 기준점이 없다면 null 반환
            return null;
        }

        private void CalculateUIPos(GameObject item, InventorySlot slot, Vector2Int[] shape, Vector2Int validOrigin)
        {
            // 모든 슬롯 위치의 평균을 구하기 위한 변수
            Vector3 sumPosition = Vector3.zero;

            foreach (Vector2Int vec2int in shape)
            {
                int targetX = slot.X + vec2int.x - validOrigin.x;
                int targetY = slot.Y + vec2int.y - validOrigin.y;

                InventorySlot targetSlot = InventoryManager.Instance.Grid[targetX, targetY];
                RectTransform rectTransform = targetSlot.GetComponent<RectTransform>();

                // 위치 합산
                sumPosition += rectTransform.position;
            }

            // 평균 위치 계산
            Vector3 averagePosition = sumPosition / shape.Length;

            // 아이템 위치 설정
            RectTransform itemTransform = item.GetComponent<RectTransform>();
            itemTransform.position = averagePosition;
        }

        public bool PlaceItem(GameObject item, InventorySlot slot, Vector2Int[] shape, InventoryItem inventoryItem)
        {
            // 배치 가능한 기준점 찾기
            Vector2Int? validOrigin = CanPlaceItem(slot, shape);
         
            // 배치 가능한 기준점이 있다면
            if (validOrigin.HasValue)
            {
                // 해당 기준점에서 슬롯 점유 상태를 업데이트
                foreach (Vector2Int offset in shape)
                {
                    int targetX = slot.X + offset.x - validOrigin.Value.x;
                    int targetY = slot.Y + offset.y - validOrigin.Value.y;

                    InventoryManager.Instance.Grid[targetX, targetY].IsOccupied = true;

                    inventoryItem.Slots.Add(new Vector2Int(targetX, targetY));
                }

                // UI 위치 계산
                CalculateUIPos(item, slot, shape, validOrigin.Value);
                // 여기서 이제 uiImage랑 alphaTarget에 장착되는 UI 추가
                inventoryItem.IsShop = false;
                return true;
            }

            // 배치 불가능하면 false 반환
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

