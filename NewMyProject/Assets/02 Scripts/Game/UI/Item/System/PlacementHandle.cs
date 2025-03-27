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
            // 모든 슬롯 위치의 평균을 구하기 위한 변수
            Vector3 sumPosition = Vector3.zero;

            foreach (Vector2Int vec2int in shape.shape)
            {
                int targetX = slot.X + vec2int.x - criteria.x;
                int targetY = slot.Y + vec2int.y - criteria.y;

                InventorySlot targetSlot = InventoryManager.Instance.Grid[targetX, targetY];
                RectTransform rectTransform = targetSlot.GetComponent<RectTransform>();

                // 위치 합산
                sumPosition += rectTransform.position;
            }

            // 평균 위치 계산
            Vector3 averagePosition = sumPosition / shape.shape.Length;

            // 아이템 위치 설정
            RectTransform itemTransform = rectTrans.GetComponent<RectTransform>();
            itemTransform.position = averagePosition;
        }

        public Vector2Int? CanPlace(InventorySlot slot, ItemShape shape)
        {
            // 모든 기준점에 대해 배치 가능 여부 확인
            foreach (Vector2Int origin in shape.shape)
            {
                bool canPlace = true;

                foreach (Vector2Int offset in shape.shape)
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

        public bool Place(RectTransform itemRectTrans, InventorySlot slot, ItemShape shape, ShopAndInventoryItem item = null)
        {
            // 배치 가능한 기준점 찾기
            Vector2Int? criteria = CanPlace(slot, shape);
            
            // 배치 가능한 기준점이 있다면
            if (criteria.HasValue)
            {
                // 해당 기준점에서 슬롯 점유 상태를 업데이트
                foreach (Vector2Int offset in shape.shape)
                {
                    int targetX = slot.X + offset.x - criteria.Value.x;
                    int targetY = slot.Y + offset.y - criteria.Value.y;

                    InventoryManager.Instance.Grid[targetX, targetY].IsOccupied = true;
                    item.SaveGridIndexs.Add(new Vector2Int(targetX, targetY));
                }

                // UI 위치 계산
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