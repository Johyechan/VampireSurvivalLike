using Manager.FSM.UIItem;
using MyUI.Interface;
using MyUtil.FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.State
{
    public class UIItemDraggingState : IState, IDragHandler, IEndDragHandler
    {
        private StateMachine _machine;

        private RectTransform _rectTrans;

        private IDraggable _dragHandle;

        private IRotation _rotationHandle;

        public UIItemDraggingState(StateMachine machine, RectTransform rectTrans, IDraggable dragHandle, IRotation rotationHandle)
        {
            _machine = machine;
            _rectTrans = rectTrans;
            _dragHandle = dragHandle;
            _rotationHandle = rotationHandle;
        }

        public void Enter()
        {
            
        }

        public void Execute()
        {
            // ��ǲ �����ؼ� ������ ���� �Ǵ��ؼ� �Ʒ� �Լ� �θ��� ��
            // _rotationHandle.Rotate();
        }

        public void Exit()
        {
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            _dragHandle.OnDrag(_rectTrans);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _dragHandle.OnDragEnd(_rectTrans);
            _machine.ChangeState(UIItemFSMManager.Instance.UIItemInformations[_rectTrans.gameObject.name].placementCheckState);
        }
    }
}

