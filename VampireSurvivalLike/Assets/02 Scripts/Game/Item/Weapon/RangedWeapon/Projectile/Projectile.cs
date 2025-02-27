using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _lifeTime = 5f;

    private ObjectPoolType _type;

    private float _damage;
    
    protected virtual void OnDisable()
    {
        StopCoroutine(DeathCoolCo());
    }

    public void Init(ObjectPoolType type, float damage)
    {
        _type = type;
        _damage = damage;
    }

    public void DeathCoolStart()
    {
        StartCoroutine(DeathCoolCo());
    }

    private IEnumerator DeathCoolCo()
    {
        yield return new WaitForSeconds(_lifeTime);
        ObjectPoolManager.Instance.ReturnObject(_type, gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();

            damageable.TakeDamage(_damage);

            ObjectPoolManager.Instance.ReturnObject(_type, gameObject);
        }
    }
}
