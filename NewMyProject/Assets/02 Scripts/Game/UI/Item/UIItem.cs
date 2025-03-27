using Manager;
using Manager.FSM.UIItem;
using MyUI.Interface;
using MyUI.Item.HandleSystem;
using MyUI.Slot;
using MyUI.State;
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

        private StateMachine _machine;

        private IDraggable _draggable;

        protected IRotation _rotation;

        protected IPlacement _placement;

        private UIItemFSMInformation _information;

        private IState _idleState;
        private IState _draggingState;
        private IState _checkState;
        private IState _successState;
        private IState _failedState;

        public ItemShape shape { get; set; }

        protected virtual void Awake()
        {
            gameObject.name += GameManager.Instance.nameNum++;

            _machine = new StateMachine();
            _canvas = FindFirstObjectByType<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
            _rectTrans = GetComponent<RectTransform>();

            shape = _so.shape;

            _draggable = new DragHandle(_canvas, _raycaster);
            _rotation = new RotationHandle();
            _placement = new PlacementHandle();

            _idleState = new UIItemIdleState(_rectTrans, this);
            _draggingState = new UIItemDraggingState(_rectTrans, this, _rotation);
            _checkState = new UIItemPlacementCheckState(_machine, _rectTrans, this, _draggable, _placement);
            _successState = new UIItemPlacementSuccessState(_machine, _rectTrans, this);
            _failedState = new UIItemPlacementFailedState(_machine, gameObject);

            _information = new UIItemFSMInformation();

            _information.idleState = _idleState;
            _information.placementSuccessState = _successState;
            _information.placementFailedState = _failedState;

            _information.originPosition = _rectTrans.position;
            _information.originRotaiton = _rectTrans.rotation;

            _information.shape = shape;

            UIItemManager.Instance.UIItemInformations.Add(gameObject.name, _information);

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