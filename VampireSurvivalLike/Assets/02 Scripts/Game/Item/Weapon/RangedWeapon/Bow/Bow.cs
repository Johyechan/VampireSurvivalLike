using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : ItemBase
{
    [SerializeField] private ItemSO _so;

    RangedAttack _attack;

    PreheatingEffect _effect;

    protected override void Awake()
    {
        base.Awake();

        _attack = transform.GetComponent<RangedAttack>();
        _effect = new PreheatingEffect();
        Init(_so, _attack, _effect);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }
}
