using Enemy.Boss.PartedBoss;
using Enemy.Boss.Struct;
using Manager;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public class RobotHeadPattern : LaserPattern
    {
        private BossPartBase _head;

        private BossAttackHandler _attackHandler;

        private LineRenderer _line;

        private LaserPatternData _patternData;

        public RobotHeadPattern(BossPartBase head, BossAttackHandler attackHandler, LineRenderer line, LaserPatternData patternData)
        {
            _head = head;
            _attackHandler = attackHandler;
            _line = line;
            _patternData = patternData;
        }

        public override void Pattern()
        {
            _head.StartCoroutine(PatternCo());
        }

        public override void PatternEnd()
        {
            _head.StopCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            yield return new WaitForSeconds(_patternData.startDelay);

            _line.enabled = true;

            Vector3 startPos = _head.transform.position;
            Vector3 endPos = (GameManager.Instance.player.transform.position - startPos).normalized;

            CreateLaser(_line, startPos, endPos, _patternData.lineWidth, Color.red, _patternData.lineLength);

            yield return new WaitForSeconds(_patternData.rotateStartDelay);

            Vector3 currentPos =  (_line.GetPosition(1) - _line.GetPosition(0)).normalized;
            Vector3 targetPos = GameManager.Instance.player.transform.position;
            int rotateDir = GetLaserMoveDirection(_line, _line.GetPosition(1), targetPos);

            yield return _head.StartCoroutine(RotateLaser(_line, currentPos, _patternData.rotateSpeed, _patternData.lineLength, _patternData.rotateTime, rotateDir));

            _line.enabled = false;

            yield return new WaitForSeconds(_patternData.patternEndDelay);
            _attackHandler.PatternEnd = true;
        }
    }
}

