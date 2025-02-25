using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemSO so { get; protected set; }

    private ItemStat _stat;
    private ItemStat _originStat;

    private IAttackStrategy _attackStrategy;

    private IEffect _effect;

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
            StatManager.Instance.ItemStatMap.Add(gameObject.name, _stat);
            Attack();
        }
    }

    protected virtual void OnDisable()
    {
        StatManager.Instance.ItemStatMap.Remove(gameObject.name);
    }

    public void Init(ItemSO so, IAttackStrategy attackStrategy, IEffect effect = null)
    {
        this.so = so;
        _attackStrategy = attackStrategy;
        _effect = effect;
        _stat = StatManager.Instance.StatSet(so);
        _originStat = _stat;
    }

    public void IncreaseStat(string str, float value)
    {
        switch(str)
        {
            case "AttackSpeed":
            {
                _stat.attackSpeed += value;
                StatManager.Instance.ItemStatMap.Remove(gameObject.name);
                StatManager.Instance.ItemStatMap.Add(gameObject.name, _stat);
            }
                break;
            case "ResetAttackSpeed":
            {
                _stat.attackSpeed = _originStat.attackSpeed;
                StatManager.Instance.ItemStatMap.Remove(gameObject.name);
                StatManager.Instance.ItemStatMap.Add(gameObject.name, _stat);
            }
                break;
            default:
            {
                Debug.LogError("증가할 스탯을 모름");
            }
                break;
        };
    }

    public void Attack()
    {
        if (_attackStrategy != null)
        {
            _attackStrategy.Attack(this);
        }
    }

    public void ApplyEffect()
    {
        if(_effect != null)
        {
            _effect.ApplyEffect(this);
        }
    }
}
