using MyInterface;
using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    public Action death;

    protected float _hp;

    public bool IsDie
    {
        get
        {
            return _isDie;
        }
    }

    protected bool _isDie;

    protected virtual void Start()
    {
        death += Death;
    }

    protected virtual void OnEnable()
    {
        death += Death;
    }

    public void TakeDamage(float damage)
    {
        if(!_isDie)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                Die();
            }
        }
    }

    protected abstract void Death();

    protected abstract void Die();
}
