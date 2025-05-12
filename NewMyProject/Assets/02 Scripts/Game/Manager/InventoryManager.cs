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
            // ��ġ ���� ���θ� �Ǵ��� ����
            bool placeSuccess = false;
            // ��ġ �ڵ鷯�� �����ͼ� ��ġ�ϴ� ����� ���
            IPlacement placement = new PlacementHandle();

            // ui �������� ����
            GameObject uiItemObj = ObjectPoolManager.Instance.GetObject(uiType, _uiItemBackpackPanel);
            UIItem uiItem = uiItemObj.GetComponent<UIItem>();
            RectTransform uiItemRectTransform = uiItem.GetComponent<RectTransform>();

            Debug.Log(uiItem);

            // ����ִ� ������ Ž��
            for(int i = 0;  i < Grid.GetLength(0); i++)
            {
                for(int j = 0; j < Grid.GetLength(1); j++)
                {
                    // ���� �������� ��縸ŭ ����ִ� ������ �����Ѵٸ� ��ġ
                    if (placement.Place(uiItemRectTransform, Grid[i, j], uiItem.shape))
                    {
                        // ��ġ ���� ���θ� �������� ����
                        placeSuccess = true;
                        // ������ ������ �߰�
                        StatManager.Instance.ChangeItemStat(uiItem.itemSO);
                        // ������ ������ų ������ �ʿ� �߰�
                        Items.Add(uiItem.name, uiItem.itemSO.objType);
                        break;
                    }
                }

                if (placeSuccess)
                    break;
            }

            // ��ġ�� ���� ���� ��� ����ҿ� ��ġ
            if(!placeSuccess)
            {
                uiItemRectTransform.SetParent(_uiItemBackpackPanel);
                float x = UnityEngine.Random.Range(42f, 840f);
                float y = UnityEngine.Random.Range(-75f, -180f);
                uiItemRectTransform.localPosition = new Vector3(x, y, 0f);
                return;
            }

            // ���� ����ҿ� ����� �� �ƴ� ��� �������� ���� ����
            OnAddItem?.Invoke();
        }
    }
}

