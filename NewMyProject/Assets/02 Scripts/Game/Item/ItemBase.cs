using Item.Effect;
using Item.Enum;
using UnityEngine;

namespace Item
{
    public class ItemBase : MonoBehaviour
    {
        public ItemSO itemSO;

        protected IItemEffect _effect;
    }
}