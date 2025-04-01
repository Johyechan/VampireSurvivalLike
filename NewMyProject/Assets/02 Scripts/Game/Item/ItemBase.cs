using Item.Enum;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] protected ItemType _itemType;

    [SerializeField] protected EffectType _effectType;

    [SerializeField] protected EffectTargetType _effectTargetType;

    [SerializeField] protected ItemSO _itemSO;
}
