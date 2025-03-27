using Manager.FSM.UIItem;
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

        public UIItemDraggingState(RectTransform rectTrans, UIItem item, IRotation rotationHandle)
        {
            _item = item;
            _rotationHandle = rotationHandle;
        }

        public void Enter()
        {
            Debug.Log("drag");
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

