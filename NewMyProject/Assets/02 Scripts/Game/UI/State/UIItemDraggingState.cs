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
            // ��ǲ �����ؼ� ������ ���� �Ǵ��ؼ� �Ʒ� �Լ� �θ��� ��
            // _rotationHandle.Rotate();
            // ȸ�� �� �� ���� ��ǥ ��� �����ϰ� _item.shape = ���� ������
        }

        public void Exit()
        {
            
        }
    }
}

