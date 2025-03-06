using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatItem : NewItemBase
{
    private ItemSO _so;
    private INewItemAttackStrategy _attackStrategy;
    private INewEffect _effect;

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void OnEnable()
    {
        // ���� ���� ����Ʈ�� ���� �߰�
    }

    protected virtual void OnDisable()
    {
        // ���� ���� ����Ʈ���� ���� ���� 
    }

    protected void Init(ItemSO so, INewItemAttackStrategy strategy, INewEffect effect)
    {
        _so = so;
        _attackStrategy = strategy;
        _effect = effect;
    }

    protected void Attack()
    {
        if (_attackStrategy != null)
        {
            _attackStrategy.Attack(_so, _effect);
        }
    }
}
