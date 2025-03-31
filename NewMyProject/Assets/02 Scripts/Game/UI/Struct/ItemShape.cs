using System;
using UnityEngine;

namespace MyUI.Struct
{
    [Serializable]
    public struct ItemShape
    {
        public Vector2Int[] shape;

        public ItemShape ShapeDeepCopy()
        {
            ItemShape newItemShape = new ItemShape();

            newItemShape.shape = new Vector2Int[shape.Length];
            for(int i = 0; i < shape.Length; i++)
            {
                newItemShape.shape[i] = shape[i];
            }

            return newItemShape;
        }
    }
}

