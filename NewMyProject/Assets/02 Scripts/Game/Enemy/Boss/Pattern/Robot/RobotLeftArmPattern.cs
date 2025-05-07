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
        private BossPartBase _rightArm;

        private CircularFirePatternData _patternData;

        public RobotLeftArmPattern(BossPartBase leftArm, BossPartBase rightArm, BossAttackHandler attackHandler, CircularFirePatternData patternData) : base(leftArm, attackHandler)
        {
            _rightArm = rightArm;
            _patternData = patternData;
        }

        protected override IEnumerator PatternCo()
        {
            int projectileCount = Random.Range(_patternData.minProjectileCount, _patternData.maxProjectileCount);
            float fireSpeed = Random.Range(_patternData.minFireSpeed, _patternData.maxFireSpeed);

            for(int i = 0; i < projectileCount; i++)
            {
                CreateProjectile(_currentPart, i, projectileCount, fireSpeed, _currentPart.Damage);
                CreateProjectile(_rightArm, i, projectileCount, fireSpeed, _currentPart.Damage);
            }

            yield return new WaitForSeconds(_patternData.patternEndDelay);
            _attackHandler.PatternEnd = true;
        }
    }
}

