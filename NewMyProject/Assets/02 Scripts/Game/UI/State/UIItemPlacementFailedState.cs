using Manager.FSM.UIItem;
using MyUtil.FSM;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemPlacementFailedState : IState
    {
        private StateMachine _machine;

        private GameObject _obj;

        public UIItemPlacementFailedState(StateMachine machine, GameObject obj)
        {
            _machine = machine;
            _obj = obj;
        }

        public void Enter()
        {
            Debug.Log("failed");

            _machine.ChangeState(UIItemFSMManager.Instance.UIItemInformations[_obj.name].idleState);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

