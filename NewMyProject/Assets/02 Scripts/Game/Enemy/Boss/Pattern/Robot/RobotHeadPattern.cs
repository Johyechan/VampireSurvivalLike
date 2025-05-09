using Enemy.Boss.PartedBoss;
using Enemy.Boss.Struct;
using Manager;
using System.Collections;
using Unity.Android.Gradle;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public class RobotHeadPattern : LaserPattern
    {
        private LineRenderer _line;

        private LaserPatternData _patternData;

        public RobotHeadPattern(BossPartBase head, BossAttackHandler attackHandler, LineRenderer line, LaserPatternData patternData) : base (head, attackHandler)
        {
            _line = line;
            _patternData = patternData;
        }

        public override void PatternEnd()
        {
            _line.enabled = false;
            base.PatternEnd();
        }

        protected override IEnumerator PatternCo()
        {
            yield return new WaitForSeconds(_patternData.startDelay);

            _line.enabled = true;

            Vector3 startPos = _currentPart.transform.position;
            Vector3 endPos = (GameManager.Instance.player.transform.position - startPos).normalized;
            CreateLaser(_line, startPos, endPos, _patternData.lineWidth, Color.red, _patternData.lineLength);
            _currentPart.StartCoroutine(RayCo());

            yield return new WaitForSeconds(_patternData.rotateStartDelay);

            Vector3 currentPos =  (_line.GetPosition(1) - _line.GetPosition(0)).normalized;
            Vector3 targetPos = GameManager.Instance.player.transform.position;
            int rotateDir = GetLaserMoveDirection(_line, _line.GetPosition(1), targetPos);

            yield return _currentPart.StartCoroutine(RotateLaser(_line, currentPos, _patternData.rotateSpeed, _patternData.lineLength, _patternData.rotateTime, rotateDir));

            _line.enabled = false;

            yield return new WaitForSeconds(_patternData.patternEndDelay);
            _attackHandler.PatternEnd = true;
        }

        private IEnumerator RayCo()
        {
            float curTime = 0;
            Vector2 dir = (_line.GetPosition(1) - _line.GetPosition(0)).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            while (curTime < _patternData.rotateStartDelay)
            {
                curTime += Time.deltaTime;
                CreateRay(_line, _patternData.lineWidth, _patternData.lineLength, 5, _currentPart.Damage);
                yield return null;
            }
        }
    }
}

