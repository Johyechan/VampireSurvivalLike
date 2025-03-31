using Manager.UI;
using MyUI.Interface;
using MyUI.Item;
using MyUI.Item.HandleSystem;
using MyUI.Slot;
using MyUtil.FSM;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemPlacementCheckState : IState
    {
        private StateMachine _machine;

        private RectTransform _rectTrans;

        private UIItem _item;

        private IDraggable _draggable;

        private IPlacement _placementHandle;

        private DragHandle _dragHandle;

        private string _objName;

        public UIItemPlacementCheckState(StateMachine machine, RectTransform rectTrans, UIItem item, IDraggable dragHandle, IPlacement placementHandle)
        {
            _machine = machine;
            _rectTrans = rectTrans;
            _item = item;
            _draggable = dragHandle;
            _placementHandle = placementHandle;
            _objName = rectTrans.gameObject.name;
        }

        public void Enter()
        {
            _dragHandle = _draggable as DragHandle;

            if (_dragHandle.CurrentSlot != null)
            {
                InventorySlot slot = _dragHandle.CurrentSlot.GetComponent<InventorySlot>();
                
                if (_placementHandle.Place(_rectTrans, slot, _item.shape))
                {
                    
                    _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_objName].placementSuccessState);
                }
                else
                {
                    _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_objName].placementFailedState);
                }

                _dragHandle.CurrentSlot = null;
            }
            else
            {
                _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_objName].placementFailedState);
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

