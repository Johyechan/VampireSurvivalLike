using Manager.FSM.UIItem;
using Manager.Inventory;
using MyUI.Interface;
using MyUI.State;
using MyUI.Struct;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.Item
{
    public class ShopAndInventoryItem : UIItem
    {
        protected override void Start()
        {
            base.Start();

            _idleState = new UIItemIdleState(_rectTrans, this);
            _draggingState = new UIItemDraggingState(_rectTrans, this, _rotation);
            _checkState = new UIItemPlacementCheckState(_machine, _rectTrans, this, _draggable, _placement);
            _successState = new UIItemPlacementSuccessState(_machine, _rectTrans, this);
            _failedState = new UIItemPlacementFailedState(_machine, gameObject);

            _information = new UIItemFSMInformation();

            _information.idleState = _idleState;
            _information.placementSuccessState = _successState;
            _information.placementFailedState = _failedState;

            _information.parent = _rectTrans.parent;
            _information.originPosition = _rectTrans.localPosition;
            _information.originRotaiton = _rectTrans.rotation;

            _information.shape = shape;

            UIItemManager.Instance.UIItemInformations.Add(gameObject.name, _information);
        }
    }
}

