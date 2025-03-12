using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemSO", menuName = "SO/ShopItem", order = 0)]
public class ShopItemSO : ScriptableObject
{
    public ObjectPoolType type;
}
