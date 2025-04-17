using Manager;
using Manager.Inventory;
using Manager.UI;
using MyUI.Item;
using MyUtil.FSM;
using MyUtil.Pool;
using UnityEngine;

namespace MyUI.State
{
    public class UIItemSalesState : IState
    {
        private GameObject _obj;

        private GameObject _textObj;

        private UIItem _item;

        private PlayerWallet _wallet;

        private RectTransform _rectTrans;

        private int _price;

        private ObjectPoolType _type;

        public UIItemSalesState(GameObject obj, GameObject textObj, UIItem item, int price, ObjectPoolType type)
        {
            _wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
            _rectTrans = obj.GetComponent<RectTransform>();
            _obj = obj;
            _textObj = textObj;
            _item = item;
            _price = price;
            _type = type;
        }

        public void Enter()
        {
            _wallet.AddMoney(_price);
            _item.isInventoryItem = false;
            _rectTrans.anchorMin = new Vector2(0.5f, 0.5f);
            _rectTrans.anchorMax = new Vector2(0.5f, 0.5f);
            _rectTrans.pivot = new Vector2(0.5f, 0.5f);
            _textObj.SetActive(true);
            if(InventoryManager.Instance.Items.ContainsKey(_rectTrans.gameObject.name))
            {
                StatManager.Instance.ChangeItemStat(_item.itemSO, -1);
                InventoryManager.Instance.Items.Remove(_rectTrans.gameObject.name);
            }
            ObjectPoolManager.Instance.ReturnObj(_type, _obj);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

