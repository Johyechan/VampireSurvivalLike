using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : ItemBase
{
    [SerializeField] private ItemSO _so;

    private MeleeAttack _attack;

    protected override void Awake()
    {
        base.Awake();

        _attack = GetComponent<MeleeAttack>();

        Init(_so, _attack);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
