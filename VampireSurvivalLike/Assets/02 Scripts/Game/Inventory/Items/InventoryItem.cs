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

        private List<Vector2Int> _slots = new List<Vector2Int>();
        public List<Vector2Int> Slots { get { return _slots; } set { _slots = value; } }

        private RectTransform _rectTransform;

        protected override void Awake()
        {
            base.Awake();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _shape = so.shape;
            RemoveItem(_slots);
            _slots.RemoveAll(slot => slot != null);

            _rectTransform = GetComponent<RectTransform>();

            Image followIconImage = GetComponent<Image>();
            followIconImage.raycastTarget = false;

            UpdateFollowIconPosition(eventData, _rectTransform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateFollowIconPosition(eventData, _rectTransform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GameObject slotObj = UIMousePos();

            if (slotObj != null)
            {
                InventorySlot slot = slotObj.GetComponent<InventorySlot>();

                if (!PlaceItem(gameObject, slot, _shape, this))
                {
                    Destroy(gameObject);
                    _rectTransform = null;
                }

                Image followIconImage = GetComponent<Image>();
                followIconImage.raycastTarget = true;
                _rectTransform = null;
            }
            else
            {
                Destroy(gameObject);
                _rectTransform = null;
            }
        }
    }
}

