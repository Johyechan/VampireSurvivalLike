using Manager.FSM.UIItem;
using MyUI.Interface;
using MyUI.Item.HandleSystem;
using MyUI.Struct;
using MyUtil.FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.State
{
    public class UIItemIdleState : IState, IBeginDragHandler
    {
        private StateMachine _machine;

        private RectTransform _rectTrans;

        private IDraggable _dragHandle;

        public UIItemIdleState(StateMachine machine, RectTransform rectTrans, Vector3 firstPos, IDraggable dragHandle)
        {
            _machine = machine;
            _rectTrans = rectTrans;
            _dragHandle = dragHandle;
        }

        public void Enter()
        {
            _rectTrans.position = UIItemFSMManager.Instance.UIItemInformations[_rectTrans.gameObject.name].originPos;
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _dragHandle.OnDragStart(_rectTrans);
            _machine.ChangeState(UIItemFSMManager.Instance.UIItemInformations[_rectTrans.gameObject.name].draggingState);
        }
    }
}

