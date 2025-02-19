using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemSO So { get; protected set; }
    private IAttackStrategy _attackStrategy;
    private IEffect _effect;

    public void Init(ItemSO so, IAttackStrategy attackStrategy, IEffect effect = null)
    {
        So = so;
        _attackStrategy = attackStrategy;
        _effect = effect;
    }

    public void Attack()
    {
        _attackStrategy.Attack(this);
    }

    public void ApplyEffect()
    {
        _effect.ApplyEffect(this);
    }
}
