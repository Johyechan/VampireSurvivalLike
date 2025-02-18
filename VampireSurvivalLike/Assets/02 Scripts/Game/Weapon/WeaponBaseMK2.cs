using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBaseMK2
{
    public string ItemName { get; protected set; }
    public int ItemNum { get; protected set; }
    public ObjectPoolType type { get; protected set; }
}
