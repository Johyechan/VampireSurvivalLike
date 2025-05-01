using Enemy.Boss.Interface;
using Enemy.Boss.Projectile;
using MyUtil;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotLeftArmPattern : CircularFirePattern
    {
        private BossPartBase _leftArm;
        private BossPartBase _rightArm;

        private BossAttackHandler _attackHandler;

        private int _minProjectileCount;
        private int _maxProjectileCount;

        private float _minFireSpeed;
        private float _maxFireSpeed;
        private float _projectileDamage;

        public RobotLeftArmPattern(BossPartBase leftArm, BossPartBase rightArm, BossAttackHandler attackHandler, int minProjectileCount, int maxProjectileCount, float minFireSpeed, float maxFireSpeed, float projectileDamage)
        {
            _leftArm = leftArm;
            _rightArm = rightArm;
            _attackHandler = attackHandler;
            _minProjectileCount = minProjectileCount;
            _maxProjectileCount = maxProjectileCount;
            _minFireSpeed = minFireSpeed;
            _maxFireSpeed = maxFireSpeed;
            _projectileDamage = projectileDamage;
        }

        public override void Pattern()
        {
            _leftArm.StartCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            int projectileCount = Random.Range(_minProjectileCount, _maxProjectileCount);
            float fireSpeed = Random.Range(_minFireSpeed, _maxFireSpeed);

            for(int i = 0; i < projectileCount; i++)
            {
                CreateProjectile(_leftArm, i, projectileCount, fireSpeed, _projectileDamage);
                CreateProjectile(_rightArm, i, projectileCount, fireSpeed, _projectileDamage);
            }

            yield return new WaitForSeconds(3);
            _attackHandler.PatternEnd = true;
        }
    }
}

