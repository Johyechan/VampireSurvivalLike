using Enemy.Boss.PartedBoss;
using Enemy.Boss.Struct;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public class RobotBodyPattern : DashPattern
    {
        private Transform _bossTrans;

        private DashPatternData _patternData;

        public RobotBodyPattern(Transform bossTrans, BossPartBase body, BossAttackHandler attackHandler, DashPatternData patternData) : base(body, attackHandler)
        {
            _bossTrans = bossTrans;
            _patternData = patternData;
        }

        public override void PatternEnd()
        {
            _bossTrans.position = _bossTrans.position;
            base.PatternEnd();
        }

        protected override IEnumerator PatternCo()
        {
            float curTime = 0;
            
            Vector3 dir = FindPlayerDirection(_bossTrans);

            while(curTime < _patternData.backMovingTime)
            {
                curTime += Time.deltaTime;
                _bossTrans.position -= dir * _patternData.backMovingSpeed * Time.deltaTime;
                yield return null;
            }

            curTime = 0;
            _currentPos = _bossTrans.position;

            while (curTime < _patternData.shakeTime)
            {
                curTime += Time.deltaTime;
                DashAnimation(_bossTrans, _patternData.shakePower);
                yield return null;
            }

            curTime = 0;

            while (curTime < _patternData.dashTime)
            {
                curTime += Time.deltaTime;
                _bossTrans.position += dir * _patternData.dashSpeed * Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(_patternData.patternEndDelay);

            _attackHandler.PatternEnd = true;
        }
    }
}

