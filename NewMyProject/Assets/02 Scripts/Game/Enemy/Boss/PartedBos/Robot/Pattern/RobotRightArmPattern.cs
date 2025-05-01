using Enemy.Boss.Interface;
using Enemy.Boss.Projectile;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotRightArmPattern : CircularFirePattern
    {
        private BossPartBase _rightArm;
        private BossPartBase _leftArm;

        private BossAttackHandler _attackHandler;

        private int _minProjectileCount;
        private int _maxProjectileCount;

        private float _minFireSpeed;
        private float _maxFireSpeed;
        private float _projectileDamage;

        public RobotRightArmPattern(BossPartBase rightArm, BossPartBase leftArm, BossAttackHandler attackHandler, int minProjectileCount, int maxProjectileCount, float minFireSpeed, float maxFireSpeed, float projectileDamage)
        {
            _rightArm = rightArm;
            _leftArm = leftArm;
            _attackHandler = attackHandler;
            _minProjectileCount = minProjectileCount;
            _maxProjectileCount = maxProjectileCount;
            _minFireSpeed = minFireSpeed;
            _maxFireSpeed = maxFireSpeed;
            _projectileDamage = projectileDamage;
        }

        public override void Pattern()
        {

            _rightArm.StartCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            int projectileCount = Random.Range(_minProjectileCount, _maxProjectileCount);
            float fireSpeed = Random.Range(_minFireSpeed, _maxFireSpeed);

            for (int i = 0; i < projectileCount; i++)
            {
                CreateProjectile(_rightArm, i, projectileCount, fireSpeed, _projectileDamage);
                CreateProjectile(_leftArm, i, projectileCount, fireSpeed, _projectileDamage);
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(3);

            _attackHandler.PatternEnd = true;
        }
    }
}

