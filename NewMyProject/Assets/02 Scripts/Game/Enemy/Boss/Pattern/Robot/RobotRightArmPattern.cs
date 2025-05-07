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
        private BossPartBase _rightArm;
        private BossPartBase _leftArm;

        private BossAttackHandler _attackHandler;

        private CircularFirePatternData _patternData;

        private float _fireDelay;

        public RobotRightArmPattern(BossPartBase rightArm, BossPartBase leftArm, BossAttackHandler attackHandler, CircularFirePatternData patternData, float fireDelay)
        {
            _rightArm = rightArm;
            _leftArm = leftArm;
            _attackHandler = attackHandler;
            _patternData = patternData;
            _fireDelay = fireDelay;
        }

        public override void Pattern()
        {
            _rightArm.StartCoroutine(PatternCo());
        }

        public override void PatternEnd()
        {
            _rightArm.StopCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            int projectileCount = Random.Range(_patternData.minProjectileCount, _patternData.maxProjectileCount);
            float fireSpeed = Random.Range(_patternData.minFireSpeed, _patternData.maxFireSpeed);

            for (int i = 0; i < projectileCount; i++)
            {
                CreateProjectile(_rightArm, i, projectileCount, fireSpeed, _patternData.projectileDamage);
                CreateProjectile(_leftArm, i, projectileCount, fireSpeed, _patternData.projectileDamage);
                yield return new WaitForSeconds(_fireDelay);
            }

            yield return new WaitForSeconds(_patternData.patternEndDelay);

            _attackHandler.PatternEnd = true;
        }
    }
}

