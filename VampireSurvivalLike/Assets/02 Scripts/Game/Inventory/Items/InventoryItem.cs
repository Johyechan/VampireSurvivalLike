using Manager;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItem : UIItem, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public InventoryItemSO so { get; set; }

        private bool _isShop;

        public bool IsShop { get { return _isShop; } set { _isShop = value; } }

        private List<Vector2Int> _slots = new List<Vector2Int>();
        public List<Vector2Int> Slots { get { return _slots; } set { _slots = value; } }

        private RectTransform _rectTransform;

        private Vector3 _origin;

        protected override void Awake()
        {
            base.Awake();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!_isShop)
            {
                _shape = so.shape;
                RemoveItem(_slots);
                _slots.RemoveAll(slot => slot != null);

                _rectTransform = GetComponent<RectTransform>();
                _origin = _rectTransform.localPosition;

                Image followIconImage = GetComponent<Image>();
                followIconImage.raycastTarget = false;

                UpdateFollowIconPosition(eventData, _rectTransform);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(!_isShop)
            {
                UpdateFollowIconPosition(eventData, _rectTransform);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!_isShop)
            {
                GameObject slotObj = UIMousePos("Shop");

                if (slotObj != null)
                {
                    if(slotObj.CompareTag("Shop"))
                    {
                        Image image = transform.GetComponent<Image>();
                        UIManager.Instance.UIs.Remove(image.name);
                        Destroy(gameObject);
                        PlayerWallet wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
                        wallet.AddMoney(so.price);
                    }
                    else
                    {
                        InventorySlot slot = slotObj.GetComponent<InventorySlot>();

                        if (!PlaceItem(gameObject, slot, _shape, this))
                        {
                            _rectTransform.localPosition = _origin;
                        }
                        Image followIconImage = GetComponent<Image>();
                        followIconImage.raycastTarget = true;
                        _rectTransform = null;
                    }
                }
                else
                {
                    _rectTransform.localPosition = _origin;
                    Image followIconImage = GetComponent<Image>();
                    followIconImage.raycastTarget = true;
                    _rectTransform = null;
                }
            }
        }
    }
}

