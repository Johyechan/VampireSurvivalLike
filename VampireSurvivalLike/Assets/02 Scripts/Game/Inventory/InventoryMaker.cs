using Manager;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pool;
using MyUI;
using System.Linq;

namespace Inventory
{
    public class InventoryMaker : MonoBehaviour
    {
        private PlayerBackpack _backpack;

        [Header("Alpha")]
        [SerializeField] private int _backgroundAlphaValue;
        [SerializeField] private int _slotAlphaValue;

        [Header("PlayerBackpack Inventory")]
        [SerializeField] private int _slotWidth;
        [SerializeField] private int _slotHeight;
        [SerializeField] private float _slotSpacing;

        [Header("Shop")]
        [SerializeField] private int _shopX;
        [SerializeField] private int _shopY;
        [SerializeField] private int _shopWidth;
        [SerializeField] private int _shopHeight;
        [SerializeField] private float _shopSpacing;

        private GameObject[,] _slots;
        public GameObject[,] Slots
        {
            get
            {
                return _slots;
            }
        }

        [Header("Parent")]
        [SerializeField] private GameObject _parentPanel;
        [SerializeField] private Transform _shopParent;
        [SerializeField] private Transform _backpackParent;

        private bool _isOpen;

        private void Start()
        {
            _isOpen = false;

            _backpack = GameManager.Instance.player.GetComponent<PlayerBackpack>();

            InventoryManager.Instance.shopCount = _shopX + _shopY;
            UIManager.Instance.AddUI(new List<ObjectPoolType> { ObjectPoolType.BowIcon, ObjectPoolType.SwordIcon, ObjectPoolType.TorchIcon }, _shopParent, _shopX, _shopY, _shopWidth, _shopHeight, _shopSpacing);
            _slots = UIManager.Instance.AddUI(new List<ObjectPoolType> { ObjectPoolType.Slot }, _backpackParent, GameManager.Instance.x, GameManager.Instance.y, _slotWidth, _slotHeight, _slotSpacing, _backpack.BackpackArr);

            UIController[] uis = _parentPanel.GetComponentsInChildren<UIController>(true);
            for(int i = 0; i < uis.Length; i++)
            {
                UIManager.Instance.UIs.Add(uis[i].name, uis[i]);
            }
            foreach(var ui in UIManager.Instance.UIs)
            {
                if(ui.Key.Contains("Slot"))
                {
                    InventorySlot slot = ui.Value.gameObject.GetComponent<InventorySlot>();
                    if(!slot.IsUsing)
                    {
                        slot.gameObject.SetActive(false);
                    }
                }
            }
        }

        private void Update()
        {
            if(InventoryManager.Instance.shopCount <= 0)
            {
                FillShopItem();
            }
        }

        public void FillShopItem(bool reroll = false)
        {
            if(reroll)
            {
                RemoveShopItem();
            }

            InventoryManager.Instance.shopCount = _shopX + _shopY;
            UIManager.Instance.AddUI(new List<ObjectPoolType> { ObjectPoolType.BowIcon, ObjectPoolType.SwordIcon, ObjectPoolType.TorchIcon }, _shopParent, _shopX, _shopY, _shopWidth, _shopHeight, _shopSpacing);

            UIController[] uis = _parentPanel.GetComponentsInChildren<UIController>(true);
            for (int i = 0; i < uis.Length; i++)
            {
                if (!UIManager.Instance.UIs.ContainsKey(uis[i].name))
                {
                    UIManager.Instance.UIs.Add(uis[i].name, uis[i]);
                    UIController controller = uis[i].GetComponent<UIController>();
                    if(!controller.isNotStartEnable)
                    {
                        controller.ChangeAlpha(true);
                    }
                }
            }
        }

        private void RemoveShopItem()
        {
            foreach(var ui in UIManager.Instance.UIs.ToList())
            {
                if(ui.Key.Contains("ShopItem_"))
                {
                    UIManager.Instance.UIs[ui.Key].ChangeAlpha(false, 0.1f);
                    UIManager.Instance.UIs[ui.Value.transform.GetChild(0).name].ChangeAlpha(false, 0.1f);
                    UIManager.Instance.UIs.Remove(ui.Key);
                    ObjectPoolManager.Instance.ReturnObject(ObjectPoolType.BowIcon, ui.Value.gameObject);
                }
            }
        }

        public void MakeInventory()
        {
            if (Input.GetKeyDown(KeyCode.P) && !UIManager.Instance.IsRunning)
            {
                if (!_isOpen)
                {
                    Time.timeScale = 0;
                    UIManager.Instance.IsRunning = true;
                    _parentPanel.SetActive(true);
                    _isOpen = true;
                    foreach (var uis in UIManager.Instance.UIs)
                    {
                        if(!uis.Value.isNotStartEnable)
                        {
                            uis.Value.ChangeAlpha(true);
                        }
                    }
                    UIManager.Instance.End(UIManager.Instance.delay);
                }
                else
                {
                    foreach(var uis in UIManager.Instance.UIs)
                    {
                        uis.Value.ChangeAlpha(false);
                    }
                    UIManager.Instance.FadeOutEnd(UIManager.Instance.delay, _parentPanel);
                    _backpack.GetBackpackWeapon();
                    GameObject[] weapons = new GameObject[GameManager.Instance.player.transform.childCount];
                    for(int i = 0; i < weapons.Length; i++)
                    {
                        weapons[i] = GameManager.Instance.player.transform.GetChild(i).gameObject;
                    }
                    _backpack.CalculateWeaponPos(weapons, 2);
                    _isOpen = false;
                }
            }
        }
    }
}

