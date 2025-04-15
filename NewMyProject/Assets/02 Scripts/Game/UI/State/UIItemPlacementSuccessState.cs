using Item.Enum;
using Manager;
using Manager.Inventory;
using Manager.UI;
using MyUI.Item;
using MyUI.Struct;
using MyUtil.FSM;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemPlacementSuccessState : IState
    {
        private StateMachine _machine;

        private RectTransform _rectTrans;

        private UIItem _item;

        private UIItemFSMInformation _information;

        private string _objName;

        // 위치 및 모양 저장
        public UIItemPlacementSuccessState(StateMachine machine, RectTransform rectTrans, UIItem item)
        {
            _machine = machine;
            _rectTrans = rectTrans;
            _item = item;
            _objName = rectTrans.gameObject.name;
        }

        public void Enter()
        {
            _information = UIItemManager.Instance.UIItemInformations[_objName];
            _information.originPosition = _rectTrans.localPosition;
            _information.originRotaiton = _rectTrans.rotation;
            _information.parent = _rectTrans.parent;
            _information.shape = _item.shape.ShapeDeepCopy();
            UIItemManager.Instance.UIItemInformations[_objName] = _information;

            StatManager.Instance.AddItemStat(_item.itemSO);
            InventoryManager.Instance.Items.Add(_objName, _item.itemSO.objType);

            if (UIManager.Instance.shopItemParent.transform.childCount <= 0)
            {
                UIManager.Instance.Refill();
            }

            _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_objName].idleState);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

