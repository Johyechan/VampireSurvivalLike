using Manager.FSM.UIItem;
using MyUI.Interface;
using MyUI.Slot;
using MyUtil.FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.State
{
    public class UIItemPlacementCheckState : IState
    {
        private StateMachine _machine;

        private RectTransform _rectTrans;

        private UIItemSO _so;

        private IDraggable _dragHandle;

        private IPlacement _placementHandle;

        public UIItemPlacementCheckState(StateMachine machine, RectTransform rectTrans, UIItemSO so, IDraggable dragHandle, IPlacement placementHandle)
        {
            _machine = machine;
            _rectTrans = rectTrans;
            _so = so;
            _dragHandle = dragHandle;
            _placementHandle = placementHandle;
        }

        public void Enter()
        {
            _dragHandle.OnDragEnd(_rectTrans);

            if (_dragHandle.GetObject() != null)
            {
                InventorySlot slot = _dragHandle.GetObject().GetComponent<InventorySlot>();
                if (_placementHandle.Place(_rectTrans, slot, _so.shape))
                {
                    _machine.ChangeState(UIItemFSMManager.Instance.UIItemInformations[_rectTrans.gameObject.name].placementSuccessState);
                }
                else
                {
                    _machine.ChangeState(UIItemFSMManager.Instance.UIItemInformations[_rectTrans.gameObject.name].placementFailedState);
                }
            }
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

