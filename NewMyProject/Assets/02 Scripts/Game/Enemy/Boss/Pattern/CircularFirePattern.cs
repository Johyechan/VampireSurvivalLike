using Enemy.Boss.PartedBoss;
using MyUtil.Pool;
using MyUtil;
using UnityEngine;
using Enemy.Boss.Interface;
using System.Collections;

namespace Enemy.Boss.Pattern
{
    public abstract class CircularFirePattern : PatternBase
    {
        protected CircularFirePattern(BossPartBase currentPart, BossAttackHandler attackHandler) : base(currentPart, attackHandler)
        {
        }

        protected void CreateProjectile(BossPartBase partBase, int currentCount, int projectileCount, float fireSpeed, float damage)
        {
            GameObject projectile = ObjectPoolManager.Instance.GetObject(ObjectPoolType.NormalBossProjectile);
            projectile.transform.position = partBase.transform.position;
            projectile.transform.rotation = Quaternion.identity;

            Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * currentCount / projectileCount), Mathf.Sin(Mathf.PI * 2 * currentCount / projectileCount));
            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

            ProjectileBase normalBossProjectile = projectile.GetComponent<ProjectileBase>();
            normalBossProjectile.FireSpeed = fireSpeed;
            normalBossProjectile.Damage = damage;
            normalBossProjectile.Direction = dir.normalized;

            normalBossProjectile.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}

