using Enemy.Interface.Strategy;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Boss.Transition
{
    public class BossMoveAndIdleTransition : ITransition
    {
        private StateMachine _machine;

        private BossAttackHandler _attackHandler;

        private IState _moveState;
        private IState _idleState;

        private IEnemyMoveStrategy _moveStrategy;

        public BossMoveAndIdleTransition(StateMachine machine, BossAttackHandler attackHandler, IState moveState, IState idleState, IEnemyMoveStrategy moveStrategy)
        {
            _machine = machine;
            _attackHandler = attackHandler;
            _moveState = moveState;
            _idleState = idleState;
            _moveStrategy = moveStrategy;
        }

        public bool TryTransitionToThisState()
        {
            if(_moveStrategy.CheckArea())
            {
                if(!_machine.IsCurrentState(_moveState) && _attackHandler.PatternEnd)
                {
                    _machine.ChangeState(_moveState);
                    return true;
                }
            }
            else
            {
                _machine.ChangeState(_idleState);
                return true;
            }

            return false;
        }
    }
}

