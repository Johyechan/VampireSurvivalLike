using Manager.UI;
using MyUI.Item;
using MyUtil.FSM;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemIdleState : IState
    {
        private RectTransform _rectTrans;

        private UIItem _item;

        private string _objName;

        public UIItemIdleState(RectTransform rectTrans, UIItem item)
        {
            _rectTrans = rectTrans;
            _item = item;
            _objName = rectTrans.gameObject.name;
        }

        public void Enter()
        {
            _rectTrans.SetParent(UIItemManager.Instance.UIItemInformations[_objName].parent);
            _rectTrans.localPosition = UIItemManager.Instance.UIItemInformations[_objName].originPosition;
            _rectTrans.rotation = UIItemManager.Instance.UIItemInformations[_objName].originRotaiton;
            _item.shape = UIItemManager.Instance.UIItemInformations[_objName].shape.ShapeDeepCopy();
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

