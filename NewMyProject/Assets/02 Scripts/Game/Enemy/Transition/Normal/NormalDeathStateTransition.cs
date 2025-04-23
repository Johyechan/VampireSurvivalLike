using Enemy.Interface;
using Enemy.State;
using MyUtil.FSM;
using UnityEngine;
using UnityEngine.Rendering;

namespace Enemy.Transition.Normal
{
    public class NormalDeathStateTransition : IEnemyStateTransition
    {
        private StateMachine _machine;

        private EnemyHealth _health;

        private EnemyDeathState _deathState;

        public NormalDeathStateTransition(StateMachine machine, EnemyHealth health, EnemyDeathState deathState)
        {
            _machine = machine;
            _health = health;
            _deathState = deathState;
        }

        public bool TryTransitionToThisState()
        {
            if (_health.IsDie)
            {
                if (!_machine.IsCurrentState(_deathState))
                {
                    _machine.ChangeState(_deathState);
                    return true;
                }
            }
            return false;
        }
    }
}

