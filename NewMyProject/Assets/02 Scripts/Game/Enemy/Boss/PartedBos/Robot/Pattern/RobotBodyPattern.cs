using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotBodyPattern : DashPattern
    {
        private Transform _bossTrans;

        private BossPartBase _body;

        private BossAttackHandler _attackHandler;

        public RobotBodyPattern(Transform bossTrans, BossPartBase partBase, BossAttackHandler attackHandler)
        {
            _bossTrans = bossTrans;
            _body = partBase;
            _attackHandler = attackHandler;
        }

        public override void Pattern()
        {
            _body.StartCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            float curTime = 0;
            _currentPos = _bossTrans.position;

            while(curTime < 1)
            {
                curTime += Time.deltaTime;
                ShakeAnimation(_bossTrans, 1f);
                yield return null;
            }

            curTime = 0;

            Vector3 dir = FindPlayerDirection(_bossTrans);
            while (curTime < 1)
            {
                curTime += Time.deltaTime;
                _bossTrans.position += dir * 10 * Time.deltaTime;
                yield return null;
            }

            _attackHandler.PatternEnd = true;
        }
    }
}

