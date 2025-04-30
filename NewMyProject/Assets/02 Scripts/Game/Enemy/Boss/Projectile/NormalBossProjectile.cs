using MyUtil;
using MyUtil.Interface;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Boss.Projectile
{
    public class NormalBossProjectile : ProjectileBase
    {
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();
                damageable.TakeDamage(Damage);
                ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
            }
        }
    }
}

