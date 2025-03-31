using Manager.Inventory;
using Manager.UI;
using MyUI.Item;
using MyUtil.FSM;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemDraggingState : IState
    {
        private UIItem _item;

        private string _objName;

        public UIItemDraggingState(UIItem item)
        {
            _item = item;
            _objName = item.gameObject.name;
        }

        public void Enter()
        {
            UIItemManager.Instance.CurrentUIItem = _item;

            foreach (var item in InventoryManager.Instance.ItemGrid)
            {
                if (item.Key == _objName)
                {
                    foreach (var value in item.Value)
                    {
                        Vector2Int vec = value;
                        InventoryManager.Instance.Grid[vec.x, vec.y].IsOccupied = false;
                    }
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

