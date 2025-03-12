using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DraggableItem : UIItem, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    protected RectTransform _rectTrans;

    protected GameObject _mousePointerObj;

    protected virtual void Update()
    {
        _mousePointerObj = UIMousePos(new List<string> { "Shop", "SaveBox", "Untagged" });
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (_rectTrans == null)
            _rectTrans = GetComponent<RectTransform>();

        UpdateFollowIconPosition(eventData, _rectTrans);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        UpdateFollowIconPosition(eventData, _rectTrans);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        HandleDrop(eventData);
    }

    protected abstract void HandleDrop(PointerEventData eventData);
}
