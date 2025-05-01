using Enemy.Boss.Interface;
using Enemy.Boss.Projectile;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotRightArmPattern : IBossPattern
    {
        private BossPartBase _rightArm;
        private BossPartBase _leftArm;

        private BossAttackHandler _attackHandler;

        private int _projectileCount;

        private float _patternEndDelay;
        private float _patternDelay;
        private float _fireSpeed;
        private float _projectileDamage;

        public RobotRightArmPattern(BossPartBase rightArm, BossPartBase leftArm, BossAttackHandler attackHandler, int projectileCount, float patternEndDelay, float patternDelay, float fireSpeed, float projectileDamage)
        {
            _rightArm = rightArm;
            _leftArm = leftArm;
            _attackHandler = attackHandler;
            _projectileCount = projectileCount;
            _patternEndDelay = patternEndDelay;
            _patternDelay = patternDelay;
            _fireSpeed = fireSpeed;
            _projectileDamage = projectileDamage;
        }

        public void Pattern()
        {
            _rightArm.StartCoroutine(PatternCo());
        }

        private IEnumerator PatternCo()
        {
            for (int i = 0; i < _projectileCount; i++)
            {
                CreateProjectile(_rightArm, i);
                CreateProjectile(_leftArm, i);
                yield return new WaitForSeconds(_patternDelay);
            }

            yield return new WaitForSeconds(_patternEndDelay);

            _attackHandler.PatternEnd = true;
        }

        private void CreateProjectile(BossPartBase partBase, int count)
        {
            GameObject projectile = ObjectPoolManager.Instance.GetObject(ObjectPoolType.NormalBossProjectile);
            projectile.transform.position = partBase.transform.position;
            projectile.transform.rotation = Quaternion.identity;

            Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * count / _projectileCount), Mathf.Sin(Mathf.PI * 2 * count / _projectileCount));
            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

            NormalBossProjectile normalBossProjectile = projectile.GetComponent<NormalBossProjectile>();
            normalBossProjectile.FireSpeed = _fireSpeed;
            normalBossProjectile.Damage = _projectileDamage;
            normalBossProjectile.Direction = dir.normalized;
        }
    }
}

