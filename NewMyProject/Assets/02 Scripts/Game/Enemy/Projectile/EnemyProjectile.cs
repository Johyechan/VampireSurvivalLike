using MyUtil;
using MyUtil.Interface;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Projectile
{
    // 적이 쏘는 발사체
    public class EnemyProjectile : ProjectileBase
    {
        // 플레이어에 닿을 경우 데미지
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

