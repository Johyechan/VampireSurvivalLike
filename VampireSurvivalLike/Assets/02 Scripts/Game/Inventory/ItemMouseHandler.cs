using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemMouseHandler
    {
        private Canvas _canvas;

        private GraphicRaycaster _raycaster;

        public ItemMouseHandler(Canvas canvas, GraphicRaycaster raycaster)
        {
            _canvas = canvas;
            _raycaster = raycaster;
        }

        public void UpdateFollowIconPosition(PointerEventData eventData, RectTransform rectTransform)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out Vector2 localPoint);

            if (rectTransform != null)
            {
                rectTransform.position = _canvas.transform.TransformPoint(localPoint);
            }
        }

        public GameObject UIMousePos(List<string> exceptionNames = null)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(pointer, results);

            foreach (RaycastResult result in results)
            {
                if (exceptionNames != null)
                {
                    foreach (string exceptionName in exceptionNames)
                    {
                        if (result.gameObject.CompareTag(exceptionName))
                        {
                            return result.gameObject;
                        }
                    }
                }

                InventorySlot slot = result.gameObject.GetComponent<InventorySlot>();
                if (slot != null)
                {
                    return result.gameObject;
                }
            }

            return null;
        }
    }
}

