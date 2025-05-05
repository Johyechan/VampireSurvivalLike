using Manager;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotHeadPattern : LaserPattern
    {
        private BossPartBase _head;

        private BossAttackHandler _attackHandler;

        private LineRenderer _line;

        public RobotHeadPattern(BossPartBase head, BossAttackHandler attackHandler, LineRenderer line)
        {
            _head = head;
            _attackHandler = attackHandler;
            _line = line;
        }

        public override void Pattern()
        {
            _head.StartCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            yield return new WaitForSeconds(1);

            _line.enabled = true;

            Vector3 startPos = _head.transform.position;
            Vector3 endPos = GameManager.Instance.player.transform.position - startPos;

            CreateLaser(_line, startPos, endPos.normalized * 10f, 2f, 2f, Color.red, Color.green);

            yield return new WaitForSeconds(0.5f);

            float curTime = 0;
            Vector3 currentPos = _line.GetPosition(1);
            Vector3 targetPos = Vector3.zero;
            int rotateDir = MoveLaser(_line, currentPos, targetPos);

            while (curTime < 5f)
            {
                curTime += Time.deltaTime;
                RotateLaser(_line, _head.transform.position, rotateDir);
                yield return null;
            }

            _line.enabled = false;
            _attackHandler.PatternEnd = true;
        }
    }
}

