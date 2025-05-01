using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Boss.Transition
{
    public class BossHitTransition : ITransition
    {
        private BossHealth _health;

        private StateMachine _machine;

        private IState _hitState;

        public BossHitTransition(BossHealth health, StateMachine machine, IState hitState)
        {
            _health = health;
            _machine = machine;
            _hitState = hitState;
        }

        public bool TryTransitionToThisState()
        {
            if(_health.IsHit)
            {
                _machine.ChangeState(_hitState);
                return true;
            }
            return false;
        }
    }
}

