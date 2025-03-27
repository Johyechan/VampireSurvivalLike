using Manager.FSM.UIItem;
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

        // 위치 및 모양 저장
        public UIItemPlacementSuccessState(StateMachine machine, RectTransform rectTrans, UIItem item)
        {
            _machine = machine;
            _rectTrans = rectTrans;
            _item = item;
        }

        public void Enter()
        {
            Debug.Log("success");

            _information = UIItemManager.Instance.UIItemInformations[_rectTrans.gameObject.name];
            _information.originPosition = _rectTrans.position;
            _information.originRotaiton = _rectTrans.rotation;
            _information.shape = _item.shape;
            UIItemManager.Instance.UIItemInformations[_rectTrans.gameObject.name] = _information;

            _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_rectTrans.gameObject.name].idleState);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

