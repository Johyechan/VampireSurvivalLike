using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class InventoryItem : UIItem, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        protected override void Awake()
        {
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("InvenBegin");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("InvenOn");
            UpdateFollowIconPosition(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("InvenEnd");

        }
    }
}

