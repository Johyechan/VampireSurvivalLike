using MyUtil;
using MyUtil.Interface;
using MyUtil.Pool;
using UnityEngine;

public class Arrow : ProjectileBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            damageable.TakeDamage(Damage);
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }
    }
}
