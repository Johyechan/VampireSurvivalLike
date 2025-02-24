using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreheatingEffect : IEffect
{
    public void ApplyEffect(ItemBase item)
    {
        Debug.Log("dd");
        item.IncreaseStat("AttackSpeed", 1.0f);
    }
}
