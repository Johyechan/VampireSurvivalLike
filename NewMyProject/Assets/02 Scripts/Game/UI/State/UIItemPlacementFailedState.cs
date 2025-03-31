using Manager.Inventory;
using Manager.UI;
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
            foreach (var item in InventoryManager.Instance.ItemGrid)
            {
                if (item.Key == _obj.name)
                {
                    foreach (var value in item.Value)
                    {
                        Vector2Int vec = value;
                        InventoryManager.Instance.Grid[vec.x, vec.y].IsOccupied = true;
                    }
                }
            }

            _machine.ChangeState(UIItemManager.Instance.UIItemInformations[_obj.name].idleState);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

