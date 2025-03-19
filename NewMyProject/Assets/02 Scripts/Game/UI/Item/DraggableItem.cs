using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.Item
{
    public abstract class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public virtual void OnBeginDrag(PointerEventData eventData)
        {

        }

        public virtual void OnDrag(PointerEventData eventData)
        {

        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            HandleDrop(eventData);
        }

        protected abstract void HandleDrop(PointerEventData eventData);
    }
}

