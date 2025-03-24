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
            UIRaycast(rectTransform);
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

        private void UIRaycast(RectTransform rectTransform, bool setParent = false)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(pointer, results);

            foreach (var result in results)
            {
                if (result.gameObject.CompareTag("Shop") || result.gameObject.CompareTag("Backpack"))
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
                else if(result.gameObject.TryGetComponent(out InventorySlot slot))
                {
                    _currentSlot = slot;
                }
            }
        }

        public GameObject GetObject()
        {
            return _currentSlot.gameObject;
        }
    }
}