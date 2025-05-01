using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition
{
    public class BossPartIdleTransition : ITransition
    {
        private BossHealth _health;

        private StateMachine _machine;

        private IState _idleState;

        public BossPartIdleTransition(BossHealth health, StateMachine machine, IState idleState)
        {
            _health = health;
            _machine = machine;
            _idleState = idleState;
        }

        public bool TryTransitionToThisState()
        {
            if(!_health.IsHit)
            {
                if(_machine.IsCurrentState(_idleState))
                {
                    _machine.ChangeState(_idleState);
                    return true;
                }
            }
            return false;
        }
    }
}

