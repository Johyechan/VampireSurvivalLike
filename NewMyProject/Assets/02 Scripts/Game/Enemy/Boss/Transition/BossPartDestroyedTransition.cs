using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition
{
    public class BossPartDestroyedTransition : ITransition
    {
        private BossHealth _health;

        private StateMachine _machine;

        private IState _destroyedState;

        public BossPartDestroyedTransition(BossHealth health, StateMachine machine, IState destroyedState)
        {
            _health = health;
            _machine = machine;
            _destroyedState = destroyedState;
        }

        public bool TryTransitionToThisState()
        {
            if(_health.IsDead)
            {
                if(!_machine.IsCurrentState(_destroyedState))
                {
                    _machine.ChangeState(_destroyedState);
                    return true;
                }
            }

            return false;
        }
    }
}

