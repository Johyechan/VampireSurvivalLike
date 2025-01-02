using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "SO/InventoryItem", order = 0)]
public class InventoryItemSO : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public int price;
    public int width;
    public int height;
    public ObjectPoolType type;
    public Vector2Int[] shape;
}
