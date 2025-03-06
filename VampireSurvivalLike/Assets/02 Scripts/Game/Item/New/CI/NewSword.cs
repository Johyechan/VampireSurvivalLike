using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSword : CombatItem
{
    [SerializeField] private ItemSO _so;

    private INewItemAttackStrategy _attackStrategy;

    private INewEffect _effect;

    protected override void Awake()
    {
        base.Awake();

        _attackStrategy = new NewMeleeAttack();
        _effect = new EffectDecoratorBase(_effect);

        Init(_so, _attackStrategy, _effect);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
}
