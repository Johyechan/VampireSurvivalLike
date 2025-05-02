using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotBodyPattern : DashPattern
    {
        private BossPartBase _body;

        private BossAttackHandler _attackHandler;

        public RobotBodyPattern(BossPartBase partBase, BossAttackHandler attackHandler)
        {
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
            while(curTime < 1)
            {
                curTime += Time.deltaTime;
                ShakeAnimation(_body.transform, 1);
                yield return null;
            }

            curTime = 0;

            Vector3 originPos = _body.transform.position;
            while (curTime < 1)
            {
                curTime += Time.deltaTime;
                float t = Mathf.Clamp01(curTime / 1);
                _body.transform.position = Vector3.Lerp(originPos, FindPlayerDirection(_body.transform), t);
                yield return null;
            }

            _attackHandler.PatternEnd = true;
        }
    }
}

