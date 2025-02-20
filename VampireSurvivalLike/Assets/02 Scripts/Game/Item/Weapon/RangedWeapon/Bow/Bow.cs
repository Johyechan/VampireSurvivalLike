using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : ItemBase
{
    [SerializeField] private ItemSO _so;

    private void Awake()
    {
        RangedAttack attack = transform.AddComponent<RangedAttack>();
        Init(_so, attack);
    }

    private void Start()
    {
        Attack();
    }
}
