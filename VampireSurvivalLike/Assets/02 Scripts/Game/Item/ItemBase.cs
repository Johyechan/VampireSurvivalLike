using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemSO so { get; protected set; }

    private ItemStat _stat;

    private IAttackStrategy _attackStrategy;

    private IEffect _effect;

    private float _originAttackSpeed;

    private bool _isMaked = true;

    protected virtual void Awake()
    {
        gameObject.name += GameManager.Instance.itemNum++;
    }

    protected virtual void OnEnable()
    {
        if(_isMaked)
        {
            _isMaked = false;
        }
        else
        {
            if(_attackStrategy != null)
            {
                Attack();
            }
            if(_effect != null)
            {
                ApplyEffect();
            }
        }
    }

    public void Init(ItemSO so, IAttackStrategy attackStrategy, IEffect effect = null)
    {
        this.so = so;
        _attackStrategy = attackStrategy;
        _effect = effect;
        _stat = StatManager.Instance.StatSet(so);
        StatManager.Instance.ItemStatMap.Add(gameObject.name, _stat);
        _originAttackSpeed = _stat.attackSpeed;
    }

    public void IncreaseStat(string str, float value)
    {
        Action action = str switch
        {
            "AttackSpeed" => () =>
            {
                _stat.attackSpeed += value;
                StatManager.Instance.ItemStatMap.Remove(gameObject.name);
                StatManager.Instance.ItemStatMap.Add(gameObject.name, _stat);
            },
            "ReSetAttackSpeed" => () =>
            {
                _stat.attackSpeed = _originAttackSpeed;
                StatManager.Instance.ItemStatMap.Remove(gameObject.name);
                StatManager.Instance.ItemStatMap.Add(gameObject.name, _stat);
            },
            _ => () => 
            {
                Debug.LogError("증가할 스탯을 모름");
            }
        };
    }

    private void Attack()
    {
        _attackStrategy.Attack(this);
    }

    private void ApplyEffect()
    {
        _effect.ApplyEffect(this);
    }
}
