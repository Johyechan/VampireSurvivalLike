using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Boss.Transition
{
    public class BossAttackTransition : ITransition
    {
        private StateMachine _machine;

        private IState _attackState;

        private BossAttackHandler _attackHandler;

        public BossAttackTransition(StateMachine machine, BossAttackHandler attackHandler, IState attackState)
        {
            _machine = machine;
            _attackHandler = attackHandler;
            _attackState = attackState;
        }

        public bool TryTransitionToThisState()
        {
            if (_attackHandler.CanAttack)
            {
                if(!_machine.IsCurrentState(_attackState))
                {
                    _machine.ChangeState(_attackState);
                    return true;
                }
            }

            return false;
        }
    }
}

