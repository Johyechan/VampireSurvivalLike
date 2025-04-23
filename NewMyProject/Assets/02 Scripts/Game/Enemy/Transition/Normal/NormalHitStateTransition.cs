using Enemy.Interface;
using Enemy.State;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    public class NormalHitStateTransition : IEnemyStateTransition
    {
        private StateMachine _machine;

        private EnemyHealth _health;

        private EnemyHitState _hitState;

        public NormalHitStateTransition(StateMachine machine, EnemyHealth health, EnemyHitState hitState)
        {
            _machine = machine;
            _health = health;
            _hitState = hitState;
        }

        public bool TryTransitionToThisState()
        {
            if (_health.IsHit)
            {
                _machine.ChangeState(_hitState);
                _health.IsHit = false;
                return true;
            }

            return false;
        }
    }
}

