using MyUI.Interface;
using MyUI.Slot;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyUI.Item.HandleSystem
{
    public class DragHandle : IDraggable
    {
        private Canvas _canvas;

        private GraphicRaycaster _raycaster;

        public InventorySlot CurrentSlot { get { return _currentSlot; } set { _currentSlot = value; } }
        private InventorySlot _currentSlot;

        public DragHandle(Canvas canvas, GraphicRaycaster raycaster)
        {
            _canvas = canvas;
            _raycaster = raycaster;
        }

        public void OnDragStart(RectTransform rectTransform)
        {
            UIRaycast(rectTransform, true);
            UpdateFollowUI(rectTransform);
        }

        public void OnDrag(RectTransform rectTransform)
        {
            UIRaycast(rectTransform, true);
            UpdateFollowUI(rectTransform);
        }

        public void OnDragEnd(RectTransform rectTransform)
        {
             UIRaycast(rectTransform, false, true);
            UpdateFollowUI(rectTransform);
        }

        private void UpdateFollowUI(RectTransform rectTransform)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out Vector2 localPoint);

            if(rectTransform != null)
            {
                rectTransform.position = _canvas.transform.TransformPoint(localPoint);
            }
        }

        private void UIRaycast(RectTransform rectTransform, bool setParent, bool isEnd = false)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(pointer, results);

            foreach (var result in results)
            {
                if(result.gameObject.TryGetComponent(out InventorySlot slot) && isEnd)
                {
                    _currentSlot = slot;
                }
                else if (result.gameObject.CompareTag("Shop") || result.gameObject.CompareTag("Backpack") || result.gameObject.CompareTag("SaveBox"))
                {
                    if (setParent)
                    {
                        rectTransform.SetParent(result.gameObject.transform.parent);
                    }
                    else
                    {
                        rectTransform.SetParent(result.gameObject.transform);
                    }
                    break;
                }
            }
        }
    }
}