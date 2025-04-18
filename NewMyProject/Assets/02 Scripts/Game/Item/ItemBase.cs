using Item.Effect;
using Item.Enum;
using UnityEngine;

namespace Item
{
    public class ItemBase : MonoBehaviour
    {
        public ItemSO itemSO;

        public ItemEffectContainer EffectContainer { get; set; }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, itemSO.range);
        }
    }
}