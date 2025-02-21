using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemSO So { get; protected set; }
    private IAttackStrategy _attackStrategy;
    private IEffect _effect;

    public float AttackSpeed { get; private set; }
    private float _tempAttackSpeed;

    public void Init(ItemSO so, IAttackStrategy attackStrategy, IEffect effect = null)
    {
        So = so;
        _attackStrategy = attackStrategy;
        _effect = effect;
        AttackSpeed = So.attackSpeed;
        _tempAttackSpeed = AttackSpeed;
    }

    public void IncreaseStat(string str, float value)
    {
        Action action = str switch
        {
            "AttackSpeed" => () => AttackSpeed += value,
            _ => () => AttackSpeed = _tempAttackSpeed
        };
    }

    public void DecreaseStat(string str, float value)
    {
        Action action = str switch
        {
            _ => () => AttackSpeed = _tempAttackSpeed
        };
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
