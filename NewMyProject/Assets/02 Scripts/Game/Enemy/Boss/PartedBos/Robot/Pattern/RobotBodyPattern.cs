using System.Collections;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Pattern
{
    public class RobotBodyPattern : DashPattern
    {
        private Transform _bossTrans;

        private BossPartBase _body;

        private BossAttackHandler _attackHandler;

        private float _dashSpeed;
        private float _dashTime;
        private float _backMovingSpeed;
        private float _backMovingTime;
        private float _shakePower;
        private float _shakeTime;

        public RobotBodyPattern(Transform bossTrans, BossPartBase partBase, BossAttackHandler attackHandler, float dashSpeed, float dashTime, float backMovingSpeed, float backMovingTime, float shakePower, float shakeTime)
        {
            _bossTrans = bossTrans;
            _body = partBase;
            _attackHandler = attackHandler;
            _dashSpeed = dashSpeed;
            _dashTime = dashTime;
            _backMovingSpeed = backMovingSpeed;
            _backMovingTime = backMovingTime;
            _shakePower = shakePower;
            _shakeTime = shakeTime;
        }

        public override void Pattern()
        {
            _body.StartCoroutine(PatternCo());
        }

        protected override IEnumerator PatternCo()
        {
            float curTime = 0;
            
            Vector3 dir = FindPlayerDirection(_bossTrans);

            while(curTime < _backMovingTime)
            {
                curTime += Time.deltaTime;
                _bossTrans.position -= dir * _backMovingSpeed * Time.deltaTime;
                yield return null;
            }

            curTime = 0;
            _currentPos = _bossTrans.position;

            while (curTime < _shakeTime)
            {
                curTime += Time.deltaTime;
                DashAnimation(_bossTrans, _shakePower);
                yield return null;
            }

            curTime = 0;

            while (curTime < _dashTime)
            {
                curTime += Time.deltaTime;
                _bossTrans.position += dir * _dashSpeed * Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(3);

            _attackHandler.PatternEnd = true;
        }
    }
}

