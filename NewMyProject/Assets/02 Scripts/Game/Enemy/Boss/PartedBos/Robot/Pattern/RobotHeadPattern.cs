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

        private float _lineWidth;
        private float _lineLength;
        private float _rotateSpeed;
        private float _rotateTime;

        public RobotHeadPattern(BossPartBase head, BossAttackHandler attackHandler, LineRenderer line, float lineWidth, float lineLength, float rotateSpeed, float rotateTime)
        {
            _head = head;
            _attackHandler = attackHandler;
            _line = line;
            _lineWidth = lineWidth;
            _lineLength = lineLength;
            _rotateSpeed = rotateSpeed;
            _rotateTime = rotateTime;
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
            Vector3 endPos = (GameManager.Instance.player.transform.position - startPos).normalized;

            CreateLaser(_line, startPos, endPos, 2f, Color.red, 10f);

            yield return new WaitForSeconds(2f);

            Vector3 currentPos =  (_line.GetPosition(1) - _line.GetPosition(0)).normalized;
            Vector3 targetPos = GameManager.Instance.player.transform.position;
            int rotateDir = GetLaserMoveDirection(_line, _line.GetPosition(1), targetPos);

            yield return _head.StartCoroutine(RotateLaser(_line, currentPos, 10f, 10f, 5f, rotateDir));

            _line.enabled = false;
            _attackHandler.PatternEnd = true;
        }
    }
}

