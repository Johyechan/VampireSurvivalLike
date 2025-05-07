using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using Enemy.Boss.Projectile;
using Enemy.Boss.Struct;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public class RobotRightArmPattern : CircularFirePattern
    {
        private BossPartBase _leftArm;

        private CircularFirePatternData _patternData;

        private float _fireDelay;

        public RobotRightArmPattern(BossPartBase rightArm, BossPartBase leftArm, BossAttackHandler attackHandler, CircularFirePatternData patternData, float fireDelay) : base(rightArm, attackHandler)
        {
            _leftArm = leftArm;
            _patternData = patternData;
            _fireDelay = fireDelay;
        }

        protected override IEnumerator PatternCo()
        {
            int projectileCount = Random.Range(_patternData.minProjectileCount, _patternData.maxProjectileCount);
            float fireSpeed = Random.Range(_patternData.minFireSpeed, _patternData.maxFireSpeed);

            for (int i = 0; i < projectileCount; i++)
            {
                CreateProjectile(_currentPart, i, projectileCount, fireSpeed, _currentPart.Damage);
                CreateProjectile(_leftArm, i, projectileCount, fireSpeed, _currentPart.Damage);
                yield return new WaitForSeconds(_fireDelay);
            }

            yield return new WaitForSeconds(_patternData.patternEndDelay);

            _attackHandler.PatternEnd = true;
        }
    }
}

