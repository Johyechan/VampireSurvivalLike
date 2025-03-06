using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBow : CombatItem
{
    [SerializeField] private ItemSO _so;

    private INewItemAttackStrategy _strategy;

    private INewEffect _effect;

    protected override void Awake()
    {
        base.Awake();

        _strategy = GetComponent<NewRangedAttack>();

        _effect = new NoneEffect();
        _effect = new AttackSpeedIncreaseDecorator(_effect);

        Init(_so, _strategy, _effect);
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
