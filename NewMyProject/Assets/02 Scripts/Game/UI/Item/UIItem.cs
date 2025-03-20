using MyUI.Interface;
using MyUI.Item.HandleSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyUI.Item
{
    public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Canvas _canvas;

        private GraphicRaycaster _raycaster;

        private RectTransform _rectTrans;

        private IDraggable _draggable;

        protected virtual void Awake()
        {
            _canvas = FindFirstObjectByType<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
            _rectTrans = GetComponent<RectTransform>();

            _draggable = new DragHandle(_canvas, _raycaster);
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            _draggable.OnDragStart(_rectTrans);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            _draggable.OnDragStart(_rectTrans);
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            _draggable.OnDragStart(_rectTrans);
        }
    }
}

