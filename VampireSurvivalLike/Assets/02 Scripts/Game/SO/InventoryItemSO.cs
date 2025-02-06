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

    public InventoryItemSO DeepCopy()
    {
        InventoryItemSO copy = CreateInstance<InventoryItemSO>();
        copy.sprite = this.sprite;
        copy.itemName = this.itemName;
        copy.price = this.price;
        copy.width = this.width;
        copy.height = this.height;
        copy.type = this.type;

        copy.shape = new Vector2Int[this.shape.Length];
        for(int i = 0; i < this.shape.Length; i++)
        {
            copy.shape[i] = this.shape[i];
        }

        return copy;
    }
}
