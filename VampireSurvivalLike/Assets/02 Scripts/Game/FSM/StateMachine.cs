using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class StateMachine
    {
        private IState _currentState;
        private IState _lastState;
        private IState _coolTimeState;

        private bool _isCoolTime = false;

        private float _coolTime;
        private float _curTime;

        public virtual void ChangeState(IState newState)
        {
            _currentState?.Exit();

            _currentState = newState;

            _currentState?.Enter();
        }

        public void ChangeStateWithCoolTime(IState newState, float coolTime)
        {
            if(_lastState != _currentState)
            {
                _lastState = newState;
                ChangeState(newState);
            }
            else
            {
                if (!_isCoolTime)
                {
                    _isCoolTime = true;
                    _coolTime = coolTime;
                    _coolTimeState = newState;
                    _curTime = 0;
                }
            }
        }

        public virtual void UpdateExecute()
        {
            if(_isCoolTime)
            {
                _curTime += Time.deltaTime;

                if(_curTime > _coolTime)
                {
                    ChangeState(_coolTimeState);
                    _isCoolTime = false;
                }
            }
            _currentState?.Execute();
        }
    }
}

