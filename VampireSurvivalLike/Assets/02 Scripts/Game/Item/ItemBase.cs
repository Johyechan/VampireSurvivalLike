using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemSO So { get; protected set; }
    protected IAttackStrategy _attackStrategy;
    protected IEffect _effect;

    public ItemBase(ItemSO so, IAttackStrategy attackStrategy, IEffect effect)
    {
        So = so;
        _attackStrategy = attackStrategy;
        _effect = effect;
    }

    public void Attack()
    {
        _attackStrategy.Attack(this);
    }
}
