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
        [SerializeField] private InventoryItemSO _so;

        [SerializeField] private float _multiply;

        private GameObject _followIcon;

        private RectTransform _followIconRectTransform;

        private InventoryItem _followIconItem;

        protected override void Awake()
        {
            base.Awake();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _followIcon = new GameObject("FollowIcon");
            _followIcon.transform.SetParent(_canvas.transform);
            _followIconItem = _followIcon.AddComponent<InventoryItem>();
            _followIconItem.so = _so;
            _shape = _so.shape;

            Image followIconImage = _followIcon.AddComponent<Image>();
            followIconImage.sprite = _so.sprite;
            followIconImage.color = new Color(followIconImage.color.r, followIconImage.color.g, followIconImage.color.b, 0.5f);
            followIconImage.raycastTarget = false;

            _followIconRectTransform = followIconImage.GetComponent<RectTransform>();
            _followIconRectTransform.sizeDelta = new Vector2(_so.width * _multiply, _so.height * _multiply);
            _followIconRectTransform.pivot = new Vector2(0.5f, 0.5f);

            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GameObject slotObj = UIMousePos();
            if(slotObj != null)
            {
                InventorySlot slot = slotObj.GetComponent<InventorySlot>();
                if(!PlaceItem(_followIcon, slot, _shape, _followIconItem))
                {
                    Destroy(_followIcon);
                    _followIconRectTransform = null;
                    _followIconItem = null;
                }
                Image followIconImage = _followIcon.GetComponent<Image>();
                followIconImage.raycastTarget = true;
                _followIcon = null;
                _followIconRectTransform = null;
                _followIconItem = null;
            }
            else
            {
                Destroy(_followIcon);
                _followIconRectTransform = null;
                _followIconItem = null;
            }
        }
    }
}

