using Manager;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pool;

namespace Inventory
{
    public class InventoryMaker : MonoBehaviour
    {
        private PlayerBackpack _backpack;

        [SerializeField] private int _storeX;
        [SerializeField] private int _storeY;
        [SerializeField] private int _backgroundAlphaValue;
        [SerializeField] private int _slotAlphaValue;

        [SerializeField] private float _delay;

        [SerializeField] private GameObject _parentPanel;
        private GameObject[,] _slots;
        public GameObject[,] Slots
        {
            get
            {
                return _slots;
            }
        }

        [SerializeField] private Transform _shopParent;
        [SerializeField] private Transform _backpackParent;

        private bool _isOpen;

        private void Start()
        {
            _isOpen = false;

            _backpack = GameManager.Instance.player.GetComponent<PlayerBackpack>();

            UIManager.Instance.AddUI(ObjectPoolType.GunIcon, _shopParent, _storeX, _storeY);
            _slots = UIManager.Instance.AddUI(ObjectPoolType.Slot, _backpackParent, GameManager.Instance.x, GameManager.Instance.y, _backpack.BackpackArr);
            Image[] images = _parentPanel.GetComponentsInChildren<Image>(true);
            for(int i = 0; i < images.Length; i++)
            {
                UIManager.Instance.UIImages.Add(images[i]);
                if (images[i].name == "Slot(Clone)")
                {
                    if (!images[i].GetComponent<InventorySlot>().IsUsing)
                    {
                        UIManager.Instance.AlphaTargets.Add(-1);
                    }
                    else
                    {
                        UIManager.Instance.AlphaTargets.Add(_slotAlphaValue);
                    }
                }
                else
                {
                    UIManager.Instance.AlphaTargets.Add(_backgroundAlphaValue);
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
                    UIManager.Instance.Appear(UIManager.Instance.GetUIImages(), _delay, UIManager.Instance.GetAlphaTargets(), _parentPanel);
                    _isOpen = true;
                }
                else
                {
                    UIManager.Instance.Disappear(UIManager.Instance.GetUIImages(), _delay, _parentPanel);
                    _isOpen = false;
                }
            }
        }
    }
}

