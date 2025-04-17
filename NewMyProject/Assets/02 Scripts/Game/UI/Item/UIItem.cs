using Item.Enum;
using Manager;
using MyUI.Interface;
using MyUI.Item.HandleSystem;
using MyUI.Struct;
using MyUtil.FSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyUI.Item
{
    public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public UIItemSO uiItemSO;
        public ItemSO itemSO;

        private Canvas _canvas;

        private GraphicRaycaster _raycaster;

        protected RectTransform _rectTrans;

        protected StateMachine _machine;

        protected GameObject _textObj;

        protected IDraggable _draggable;

        protected IPlacement _placement;

        protected UIItemFSMInformation _information;

        protected IState _idleState;
        protected IState _draggingState;
        protected IState _checkState;
        protected IState _successState;
        protected IState _failedState;
        protected IState _buyState;
        protected IState _salesState;

        public ItemShape shape { get; set; }

        public bool isInventoryItem { get; set; }

        protected virtual void Start()
        {
            _machine = new StateMachine();
            _canvas = FindFirstObjectByType<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
            _rectTrans = GetComponent<RectTransform>();
            _textObj = transform.GetChild(0).gameObject;

            shape = uiItemSO.DeepCopy().shape;

            _draggable = new DragHandle(_canvas, _raycaster);
            _placement = new PlacementHandle();

            _machine.ChangeState(_idleState);
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            _draggable.OnDragStart(_rectTrans);
            if(!isInventoryItem)
            {
                _textObj.SetActive(false);
                _machine.ChangeState(_buyState);
            }
            else
            {
                _machine.ChangeState(_draggingState);
            }
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            _draggable.OnDrag(_rectTrans);
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            _draggable.OnDragEnd(_rectTrans);
            _machine.ChangeState(_checkState);
        }
    }
}