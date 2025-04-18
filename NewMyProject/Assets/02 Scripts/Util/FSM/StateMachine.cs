using UnityEngine;

namespace MyUtil.FSM
{
    public class StateMachine
    {
        private IState _currentState;
        private IState _delayState;

        private bool _isDelayed = false;

        private float _currentTime;
        private float _delay;

        public virtual bool IsCurrentState(IState state)
        {
            if(_currentState != state)
            {
                return false;
            }

            return true;
        }

        public virtual void ChangeState(IState state)
        {
            _currentState?.Exit();

            _currentState = state;

            _currentState?.Enter();
        }

        public virtual void DelayChangeState(IState state, float delay)
        {
            if (!_isDelayed)
            {
                _isDelayed = true;
                _delay = delay;
                _delayState = state;
                _currentTime = 0;
            }
        }

        public virtual void UpdateExecute()
        {
            if (_isDelayed)
            {
                _currentTime += Time.deltaTime;

                if (_currentTime > _delay)
                {
                    ChangeState(_delayState);
                    _isDelayed = false;
                }
            }
            
            _currentState?.Execute();
        }
    }
}

