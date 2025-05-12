using MyUI.Interface;
using MyUI.Item;
using MyUI.Item.HandleSystem;
using MyUI.Slot;
using MyUtil;
using MyUtil.Pool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public InventorySlot[,] Grid { get; set; }

        public Dictionary<string, Queue<Vector2Int>> ItemGrid { get { return _itemGrid; } }
        private Dictionary<string, Queue<Vector2Int>> _itemGrid = new Dictionary<string, Queue<Vector2Int>>();

        public Dictionary<string, ObjectPoolType> Items { get { return _items; } }
        private Dictionary<string, ObjectPoolType> _items = new Dictionary<string, ObjectPoolType>();

        public event Action OnAddItem;

        [SerializeField] private Transform _weaponItemParent;
        [SerializeField] private Transform _inventoryItemParent;
        [SerializeField] private Transform _uiItemBackpackPanel;
        [SerializeField] private Transform _uiItemSaveBoxPanel;

        public void AddItemInInventory(ObjectPoolType uiType, bool isWeapon)
        {
            // 배치 성공 여부를 판단할 변수
            bool placeSuccess = false;
            // 배치 핸들러를 가져와서 배치하는 기능을 사용
            IPlacement placement = new PlacementHandle();

            // ui 아이템을 생성
            GameObject uiItemObj = ObjectPoolManager.Instance.GetObject(uiType, _uiItemBackpackPanel);
            UIItem uiItem = uiItemObj.GetComponent<UIItem>();
            RectTransform uiItemRectTransform = uiItem.GetComponent<RectTransform>();

            Debug.Log(uiItem);

            // 비어있는 슬롯을 탐색
            for(int i = 0;  i < Grid.GetLength(0); i++)
            {
                for(int j = 0; j < Grid.GetLength(1); j++)
                {
                    // 만일 아이템의 모양만큼 비어있는 슬롯이 존재한다면 배치
                    if (placement.Place(uiItemRectTransform, Grid[i, j], uiItem.shape))
                    {
                        // 배치 성공 여부를 성공으로 결정
                        placeSuccess = true;
                        // 아이템 스탯을 추가
                        StatManager.Instance.ChangeItemStat(uiItem.itemSO);
                        // 실제로 생성시킬 아이템 맵에 추가
                        Items.Add(uiItem.name, uiItem.itemSO.objType);
                        break;
                    }
                }

                if (placeSuccess)
                    break;
            }

            // 배치에 실패 했을 경우 저장소에 배치
            if(!placeSuccess)
            {
                uiItemRectTransform.SetParent(_uiItemBackpackPanel);
                float x = UnityEngine.Random.Range(42f, 840f);
                float y = UnityEngine.Random.Range(-75f, -180f);
                uiItemRectTransform.localPosition = new Vector3(x, y, 0f);
                return;
            }

            // 만약 저장소에 저장된 게 아닌 경우 아이템을 실제 생성
            OnAddItem?.Invoke();
        }
    }
}

