using Manager.FSM.UIItem;
using MyUI.Interface;
using MyUI.Item;
using MyUI.Item.HandleSystem;
using MyUI.Struct;
using MyUtil.FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.State
{
    public class UIItemIdleState : IState
    {
        private RectTransform _rectTrans;

        private UIItem _item;

        public UIItemIdleState(RectTransform rectTrans, UIItem item)
        {
            _rectTrans = rectTrans;
            _item = item;
        }

        public void Enter()
        {
            Debug.Log("idle");
            _rectTrans.position = UIItemManager.Instance.UIItemInformations[_rectTrans.gameObject.name].originPosition;
            _rectTrans.rotation = UIItemManager.Instance.UIItemInformations[_rectTrans.gameObject.name].originRotaiton;
            _item.shape = UIItemManager.Instance.UIItemInformations[_rectTrans.gameObject.name].shape;

            // ΩΩ∑‘ √ ±‚»≠
            // UIItemManagerø°º≠ ΩΩ∑‘ µÒº≈≥ ∏Æ µÈ∞Ìø¿±‚
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

