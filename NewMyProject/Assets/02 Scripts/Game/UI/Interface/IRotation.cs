using MyUI.Struct;
using UnityEngine;

namespace MyUI.Interface
{
    public interface IRotation
    {
        public ItemShape Rotate(ItemShape shape, bool isRight = true);
    }
}

