using Item.Enum;
using Manager.UI;
using MyUI.State;
using MyUI.Struct;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

namespace MyUI.Item
{
    public class ShopAndInventoryItem : UIItem
    {
        protected override void Start()
        {
            base.Start();
            TMP_Text tmpText = transform.GetChild(0).GetComponent<TMP_Text>();
            tmpText.text = itemSO.price.ToString() + "$";

            _idleState = new UIItemIdleState(_rectTrans, this, _textObj);
            _draggingState = new UIItemDraggingState(this);
            _checkState = new UIItemPlacementCheckState(_machine, _rectTrans, this, _draggable, _placement);
            _successState = new UIItemPlacementSuccessState(_machine, _rectTrans, this);
            _failedState = new UIItemPlacementFailedState(_machine, gameObject);
            _buyState = new UIItemBuyState(_machine, itemSO.price, gameObject.name);
            _salesState = new UIItemSalesState(gameObject, _textObj, this, itemSO.price, itemSO.uiObjType);

            _information = new UIItemFSMInformation();

            _information.idleState = _idleState;
            _information.placementSuccessState = _successState;
            _information.placementFailedState = _failedState;
            _information.draggingState = _draggingState;
            _information.salesState = _salesState;

            _information.parent = _rectTrans.parent;
            _information.originPosition = _rectTrans.anchoredPosition;
            _information.originRotaiton = _rectTrans.rotation;

            _information.shape = shape.ShapeDeepCopy();

            UIItemManager.Instance.UIItemInformations.Add(gameObject.name, _information);
        }
    }
}

