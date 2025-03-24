using MyUI.Slot;
using UnityEngine;

namespace MyUI.Interface
{
    public interface IDraggable
    {
        public GameObject GetObject();

        public void OnDragStart(RectTransform rectTransform);

        public void OnDrag(RectTransform rectTransform);

        public void OnDragEnd(RectTransform rectTransform);
    }
}

