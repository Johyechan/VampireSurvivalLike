using Manager.UI;
using MyUI.Item;
using MyUtil.FSM;
using TMPro;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemIdleState : IState
    {
        private RectTransform _rectTrans;

        private UIItem _item;

        private GameObject _textObj;

        private string _objName;

        public UIItemIdleState(RectTransform rectTrans, UIItem item, GameObject textObj)
        {
            _rectTrans = rectTrans;
            _item = item;
            _textObj = textObj;
            _objName = rectTrans.gameObject.name;
        }

        public void Enter()
        {
            if (!_item.isInventoryItem)
            {
                _rectTrans.anchorMin = new Vector2(0.5f, 0.5f);
                _rectTrans.anchorMax = new Vector2(0.5f, 0.5f);
                _rectTrans.pivot = new Vector2(0.5f, 0.5f);
                _textObj.SetActive(true);
            }

            _rectTrans.SetParent(UIItemManager.Instance.UIItemInformations[_objName].parent);
            _rectTrans.anchoredPosition = UIItemManager.Instance.UIItemInformations[_objName].originPosition;
            Debug.Log(UIItemManager.Instance.UIItemInformations[_objName].originPosition);
            Debug.Log(_rectTrans.anchoredPosition);
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

