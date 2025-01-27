using Manager;
using MyUI;
using Player;
using Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class ShopItem : UIItem, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public InventoryItemSO so;

        [SerializeField] private float _multiply;

        private GameObject _followIcon;

        private RectTransform _followIconRectTransform;

        private InventoryItem _followIconItem;

        private UIController _followIconController;

        private PlayerWallet _wallet;

        private int _followIconAlpha = 255;

        private Image _image;

        private bool _isBuy;

        protected override void Awake()
        {
            base.Awake();
            _image = GetComponent<Image>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isBuy = true;
            // 이 Ui 아이템 Image 숨기기
            _wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
            if(!_wallet.UseMoney(so.price))
            {
                _isBuy = false;
                return;
            }

            UIManager.Instance.UIs[_image.gameObject.name].ChangeAlpha(false, 0.1f);
            UIManager.Instance.UIs[_image.transform.GetChild(0).name].ChangeAlpha(false, 0.1f);
            _followIcon = new GameObject("InventoryItem" + GameManager.Instance.itemNum);
            GameManager.Instance.itemNum++;

            _followIcon.transform.SetParent(_canvas.transform);
            _followIconItem = _followIcon.AddComponent<InventoryItem>();
            _followIconItem.so = so;
            _followIconItem.so.type = so.type;
            _followIconItem.IsShop = true;
            _shape = so.shape;

            _followIconController = _followIcon.AddComponent<UIController>();
            _followIconController.isImage = true;
            _followIconController.alphaValue = 255;

            Image followIconImage = _followIcon.AddComponent<Image>();
            followIconImage.sprite = so.sprite;
            followIconImage.color = new Color(followIconImage.color.r, followIconImage.color.g, followIconImage.color.b, _followIconAlpha);
            followIconImage.raycastTarget = false;

            _followIconRectTransform = followIconImage.GetComponent<RectTransform>();
            _followIconRectTransform.sizeDelta = new Vector2(so.width * _multiply, so.height * _multiply);
            _followIconRectTransform.pivot = new Vector2(0.5f, 0.5f);

            UIManager.Instance.UIs.Add(_followIcon.name, _followIconController);

            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(!_isBuy)
            {
                return;
            }

            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!_isBuy)
            {
                return;
            }

            GameObject slotObj = UIMousePos();
            
            if(slotObj != null)
            {
                InventorySlot slot = slotObj.GetComponent<InventorySlot>();
                if(!PlaceItem(_followIcon, slot, _shape, _followIconItem))
                {
                    UIManager.Instance.UIs[_image.gameObject.name].ChangeAlpha(true, 0.1f);
                    Destroy(_followIcon);
                    _followIconRectTransform = null;
                    _followIconItem = null;
                }
                else
                {
                    Image followIconImage = _followIcon.GetComponent<Image>();
                    followIconImage.raycastTarget = true;
                    _followIcon = null;
                    _followIconRectTransform = null;
                    _followIconItem = null;
                    UIManager.Instance.UIs.Remove(_image.gameObject.name);
                    ObjectPoolManager.Instance.ReturnObject(ObjectPoolType.GunIcon, gameObject);
                    InventoryManager.Instance.shopCount--;
                }
            }
            else
            {
                _wallet.AddMoney(so.price);
                UIManager.Instance.UIs[_image.gameObject.name].ChangeAlpha(true, 0.1f);
                UIManager.Instance.UIs[_image.transform.GetChild(0).name].ChangeAlpha(true, 0.1f);
                Destroy(_followIcon);
                _followIconRectTransform = null;
                _followIconItem = null;
            }
        }
    }
}

