using UnityEngine;

namespace MyUI.Interface
{
    public interface IUILayoutStrategy
    {
        public Vector2 GetPosition(RectTransform parentRectTrans, int x, int y, float width, float height, float spacing);
    }
}
