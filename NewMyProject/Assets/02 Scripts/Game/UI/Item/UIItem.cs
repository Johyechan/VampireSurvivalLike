using MyUI.Interface;
using MyUI.Item.HandleSystem;
using MyUI.Slot;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyUI.Item
{
    public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] protected UIItemSO _so;

        private Canvas _canvas;

        private GraphicRaycaster _raycaster;

        protected RectTransform _rectTrans;

        protected InventorySlot _slot;

        private IDraggable _draggable;

        protected IRotation _rotation;

        protected IPlacement _placement;

        protected virtual void Awake()
        {
            _canvas = FindFirstObjectByType<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
            _rectTrans = GetComponent<RectTransform>();

            _draggable = new DragHandle(_canvas, _raycaster);
            _rotation = new RotationHandle();
            _placement = new PlacementHandle();
        }

        protected virtual void Update()
        {

        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            _draggable.OnDragStart(_rectTrans);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            _draggable.OnDrag(_rectTrans);
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            _draggable.OnDragEnd(_rectTrans);
            _slot = _draggable.GetObject().GetComponent<InventorySlot>();
        }
    }
}

