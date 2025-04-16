using Manager;
using Manager.UI;
using MyUtil.FSM;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemBuyState : IState
    {
        private StateMachine _machine;

        private PlayerWallet _wallet;

        private int _price;

        private string _objName;

        public UIItemBuyState(StateMachine machine, int price, string objName)
        {
            _wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
            _machine = machine;
            _price = price;
            _objName = objName;
        }

        public void Enter()
        {
            if(_wallet.UseMoney(_price))
            {
                _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_objName].draggingState);
            }
            else
            {
                Debug.Log("µ· ¾ø¾î");
                _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_objName].idleState);
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

