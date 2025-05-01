using Enemy.Boss.Interface;
using Enemy.Boss.Projectile;
using MyUtil;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotLeftArmPattern : IBossPattern
    {
        private BossPartBase _leftArm;
        private BossPartBase _rightArm;

        private BossAttackHandler _attackHandler;

        private int _projectileCount;

        private float _patternEndDelay;
        private float _fireSpeed;
        private float _projectileDamage;

        public RobotLeftArmPattern(BossPartBase leftArm, BossPartBase rightArm, BossAttackHandler attackHandler, int projectileCount, float patternEndDelay, float fireSpeed, float projectileDamage)
        {
            _leftArm = leftArm;
            _rightArm = rightArm;
            _attackHandler = attackHandler;
            _projectileCount = projectileCount;
            _patternEndDelay = patternEndDelay;
            _fireSpeed = fireSpeed;
            _projectileDamage = projectileDamage;
        }

        public void Pattern()
        {
            _leftArm.StartCoroutine(PatternCo());
        }

        private IEnumerator PatternCo()
        {
            CreateProjectile(_leftArm);
            CreateProjectile(_rightArm);

            yield return new WaitForSeconds(_patternEndDelay);
            _attackHandler.PatternEnd = true;
        }

        private void CreateProjectile(BossPartBase partBase)
        {
            for (int i = 0; i < _projectileCount; i++)
            {
                GameObject projectile = ObjectPoolManager.Instance.GetObject(ObjectPoolType.NormalBossProjectile);
                projectile.transform.position = partBase.transform.position;
                projectile.transform.rotation = Quaternion.identity;

                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / _projectileCount), Mathf.Sin(Mathf.PI * 2 * i / _projectileCount));
                float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

                ProjectileBase normalBossProjectile = projectile.GetComponent<ProjectileBase>();
                normalBossProjectile.FireSpeed = _fireSpeed;
                normalBossProjectile.Damage = _projectileDamage;
                normalBossProjectile.Direction = dir.normalized;

                normalBossProjectile.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }

    }
}

