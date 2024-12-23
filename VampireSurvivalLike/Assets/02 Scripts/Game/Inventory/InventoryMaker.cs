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
        private int _backpackX;
        public int BackpackX
        {
            get
            {
                return _backpackX;
            }
        }
        private int _backpackY;
        public int BackpackY
        {
            get
            {
                return _backpackY;
            }
        }
        private int[] _alphaTargets;

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

        private Image[] _uiImages;

        private bool _isOpen;

        private void Start()
        {
            _isOpen = false;

            _backpack = GameManager.Instance.player.GetComponent<PlayerBackpack>();
            _backpackX = _backpack.X;
            _backpackY = _backpack.Y;

            UIManager.Instance.AddUI(ObjectPoolType.GunIcon, _shopParent, _storeX, _storeY);
            _slots = UIManager.Instance.AddUI(ObjectPoolType.Slot, _backpackParent, _backpackX, _backpackY);
            _uiImages = _parentPanel.GetComponentsInChildren<Image>(true);
            _alphaTargets = new int[_uiImages.Length];
            for (int i = 0; i < _uiImages.Length; i++)
            {
                if (_uiImages[i].gameObject.name == "Slot(Clone)")
                {
                    _alphaTargets[i] = _slotAlphaValue;
                }
                else
                {
                    _alphaTargets[i] = _backgroundAlphaValue;
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
                    UIManager.Instance.Appear(_uiImages, _delay, _alphaTargets, _parentPanel);
                    _isOpen = true;
                }
                else
                {
                    UIManager.Instance.Disappear(_uiImages, _delay, _parentPanel);
                    _isOpen = false;
                }
            }
        }
    }
}

