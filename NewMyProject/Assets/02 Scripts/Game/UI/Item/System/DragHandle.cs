using MyUI.Interface;
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

        public DragHandle(Canvas canvas, GraphicRaycaster raycaster)
        {
            _canvas = canvas;
            _raycaster = raycaster;
        }

        public void OnDragStart(RectTransform rectTransform)
        {
            ChangeParent(rectTransform, true);
            UpdateFollowUI(rectTransform);
        }

        public void OnDrag(RectTransform rectTransform)
        {
            ChangeParent(rectTransform, true);
            UpdateFollowUI(rectTransform);
        }

        public void OnDragEnd(RectTransform rectTransform)
        {
            ChangeParent(rectTransform);
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

        private void ChangeParent(RectTransform rectTransform, bool setParent = false)
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
            }
        }
    }
}

