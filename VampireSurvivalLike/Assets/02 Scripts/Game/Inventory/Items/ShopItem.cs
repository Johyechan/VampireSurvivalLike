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

        protected override void Awake()
        {
            base.Awake();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _followIcon = new GameObject("FollowIcon");
            _followIcon.transform.SetParent(_canvas.transform);
            _followIcon.AddComponent<InventoryItem>();
            _shape = _so.shape;

            Image followIconImage = _followIcon.AddComponent<Image>();
            followIconImage.sprite = _so.sprite;
            followIconImage.color = new Color(followIconImage.color.r, followIconImage.color.g, followIconImage.color.b, 0.5f);
            followIconImage.raycastTarget = false;

            _rectTransform = followIconImage.GetComponent<RectTransform>();
            _rectTransform.sizeDelta = new Vector2(_so.width * _multiply, _so.height * _multiply);
            _rectTransform.pivot = new Vector2(0.5f, 0.5f);

            UpdateFollowIconPosition(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateFollowIconPosition(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GameObject slotObj = UIMousePos();
            if(slotObj != null)
            {
                InventorySlot slot = slotObj.GetComponent<InventorySlot>();
                Debug.Log(slot.IsOccupied);
                Debug.Log($"X: {slot.X}");
                Debug.Log($"Y: {slot.Y}");
                if(!PlaceItem(_followIcon, slot, _shape))
                {
                    Destroy(_followIcon);
                }
            }
            else
            {
                Destroy(_followIcon);
            }
            
        }
    }
}

