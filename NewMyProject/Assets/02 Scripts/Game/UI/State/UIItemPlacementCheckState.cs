using Manager.FSM.UIItem;
using MyUI.Interface;
using MyUI.Item;
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

        private UIItem _item;

        private IDraggable _dragHandle;

        private IPlacement _placementHandle;

        public UIItemPlacementCheckState(StateMachine machine, RectTransform rectTrans, UIItem item, IDraggable dragHandle, IPlacement placementHandle)
        {
            _machine = machine;
            _rectTrans = rectTrans;
            _item = item;
            _dragHandle = dragHandle;
            _placementHandle = placementHandle;
        }

        public void Enter()
        {
            Debug.Log("check");

            _dragHandle.OnDragEnd(_rectTrans);

            if (_dragHandle.GetObject() != null)
            {
                InventorySlot slot = _dragHandle.GetObject().GetComponent<InventorySlot>();
                if (_placementHandle.Place(_rectTrans, slot, _item.shape))
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

