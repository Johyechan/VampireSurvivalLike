using Manager.FSM.UIItem;
using Manager.Inventory;
using MyUI.Interface;
using MyUI.Item;
using MyUtil.FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.State
{
    public class UIItemDraggingState : IState
    {
        private RectTransform _rectTrans;

        private UIItem _item;

        private IRotation _rotationHandle;

        private string _objName;

        public UIItemDraggingState(RectTransform rectTrans, UIItem item, IRotation rotationHandle)
        {
            _item = item;
            _rotationHandle = rotationHandle;
            _objName = rectTrans.gameObject.name;
        }

        public void Enter()
        {
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
            // 인풋 관련해서 오른쪽 왼쪽 판단해서 아래 함수 부르면 됨
            // _rotationHandle.Rotate();
            // 회전 할 때 형태 좌표 계속 갱신하고 _item.shape = 뭐다 식으로
        }

        public void Exit()
        {
            
        }
    }
}

