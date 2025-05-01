using MyUtil.Interface;
using Unity.VisualScripting;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    public float MaxHp { get; set; }
    protected float _currentHp;

    public bool IsDead { get; protected set; }
    public bool IsHit { get; set; }

    private void Start()
    {
        _currentHp = MaxHp;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHp > 0)
        {
            _currentHp -= damage;
            IsHit = true;
        }
        else
        {
            IsDead = true;
        }
    }
}
