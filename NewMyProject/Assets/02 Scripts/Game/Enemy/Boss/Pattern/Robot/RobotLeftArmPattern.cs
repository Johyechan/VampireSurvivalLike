using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using Enemy.Boss.Projectile;
using Enemy.Boss.Struct;
using MyUtil;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public class RobotLeftArmPattern : CircularFirePattern
    {
        private BossPartBase _leftArm;
        private BossPartBase _rightArm;

        private BossAttackHandler _attackHandler;

        private CircularFirePatternData _patternData;

        public RobotLeftArmPattern(BossPartBase leftArm, BossPartBase rightArm, BossAttackHandler attackHandler, CircularFirePatternData patternData)
        {
            _leftArm = leftArm;
            _rightArm = rightArm;
            _attackHandler = attackHandler;
            _patternData = patternData;
        }

        public override void Pattern()
        {
            _leftArm.StartCoroutine(PatternCo());
        }

        public override void PatternEnd()
        {
            _leftArm.StopCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            int projectileCount = Random.Range(_patternData.minProjectileCount, _patternData.maxProjectileCount);
            float fireSpeed = Random.Range(_patternData.minFireSpeed, _patternData.maxFireSpeed);

            for(int i = 0; i < projectileCount; i++)
            {
                CreateProjectile(_leftArm, i, projectileCount, fireSpeed, _patternData.projectileDamage);
                CreateProjectile(_rightArm, i, projectileCount, fireSpeed, _patternData.projectileDamage);
            }

            yield return new WaitForSeconds(_patternData.patternEndDelay);
            _attackHandler.PatternEnd = true;
        }
    }
}

