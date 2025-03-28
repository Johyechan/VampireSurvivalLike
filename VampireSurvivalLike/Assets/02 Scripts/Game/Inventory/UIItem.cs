using Manager;
using MySO;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class UIItem : MonoBehaviour
    {
        protected Canvas _canvas;

        protected GraphicRaycaster _raycaster;

        protected Vector2Int[] _shape;

        private UIItemPlacement _itemPlacement;

        private UIItemRotator _itemRotator;

        private ItemMouseHandler _mouseHandler;

        protected virtual void Awake()
        {
            _canvas = FindObjectOfType<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
            _itemPlacement = transform.AddComponent<UIItemPlacement>();
            _itemRotator = transform.AddComponent<UIItemRotator>();
            _mouseHandler = new ItemMouseHandler(_canvas, _raycaster);
        }

        protected void ChangeParentAndScale(GameObject obj, Transform trans, RectTransform rectTrans, InventoryItemSO so, float multiply)
        {
            if (obj.CompareTag("SaveBox"))
            {
                trans.SetParent(obj.transform);
                rectTrans.sizeDelta = new Vector2(so.width * (multiply / 2), so.height * (multiply / 2));
            }
            else
            {
                trans.SetParent(_canvas.transform);
                rectTrans.sizeDelta = new Vector2(so.width * multiply, so.height * multiply);
            }
        }

        protected void ItemRotate(RectTransform rectTrans, Vector2Int[] shape)
        {
            //string debugLog = "";
            if (Input.GetKeyDown(KeyCode.Q))
            {
                rectTrans.Rotate(0, 0, 90);
                shape = RotateItem(shape, false);
                //for (int i = 0; i < _shape.Length; i++)
                //{
                //    debugLog += _shape[i] + " ";
                //}
                //Debug.Log("Q: 90도 회전" + debugLog);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                rectTrans.Rotate(0, 0, -90);
                shape = RotateItem(shape);
                //for (int i = 0; i < _shape.Length; i++)
                //{
                //    debugLog += _shape[i] + " ";
                //}
                //Debug.Log("E: -90도 회전" + debugLog);
            }
        }

        protected void UpdateFollowIconPosition(PointerEventData eventData, RectTransform rectTransform)
        {
            _mouseHandler.UpdateFollowIconPosition(eventData, rectTransform);
        }

        protected Vector2Int[] RotateItem(Vector2Int[] shape, bool right = true)
        {
            return _itemRotator.RotateItem(shape, right);
        }

        protected GameObject UIMousePos(List<string> exceptionNames = null)
        {
            return _mouseHandler.UIMousePos(exceptionNames);
        }

        protected bool CanPlaceItem(InventorySlot slot, Vector2Int[] shape)
        {
            return _itemPlacement.CanPlaceItem(slot, shape) != null ? true : false;
        }

        protected void PlaceItem(GameObject item, InventorySlot slot, Vector2Int[] shape, InventoryItem inventoryItem)
        {
            _itemPlacement.PlaceItem(item, slot, shape, inventoryItem);
        }

        protected void RemoveItem(List<Vector2Int> slots)
        {
            foreach (Vector2Int slot in slots)
            {
                InventoryManager.Instance.Grid[slot.x, slot.y].IsOccupied = false;
            }
        }

        protected void GetBackItem(List<Vector2Int> slots)
        {
            foreach(Vector2Int slot in slots)
            {
                InventoryManager.Instance.Grid[slot.x, slot.y].IsOccupied = true;
            }
        }
    }
}

