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
        [SerializeField] protected UIItemSO _so;

        private Canvas _canvas;

        private GraphicRaycaster _raycaster;

        protected RectTransform _rectTrans;

        protected StateMachine _machine;

        protected IDraggable _draggable;

        protected IPlacement _placement;

        protected UIItemFSMInformation _information;

        protected IState _idleState;
        protected IState _draggingState;
        protected IState _checkState;
        protected IState _successState;
        protected IState _failedState;

        public ItemShape shape { get; set; }

        protected virtual void Start()
        {
            gameObject.name += GameManager.Instance.nameNum++;

            _machine = new StateMachine();
            _canvas = FindFirstObjectByType<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
            _rectTrans = GetComponent<RectTransform>();

            shape = _so.DeepCopy().shape;

            _draggable = new DragHandle(_canvas, _raycaster);
            _placement = new PlacementHandle();

            _machine.ChangeState(_idleState);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _draggable.OnDragStart(_rectTrans);
            _machine.ChangeState(_draggingState);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _draggable.OnDrag(_rectTrans);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _draggable.OnDragEnd(_rectTrans);
            _machine.ChangeState(_checkState);
        }
    }
}