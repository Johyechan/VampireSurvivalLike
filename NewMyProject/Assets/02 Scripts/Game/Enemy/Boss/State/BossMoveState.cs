using Enemy.Interface.Strategy;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossMoveState : IState
    {
        private IEnemyMoveStrategy _moveStrategy;

        public BossMoveState(IEnemyMoveStrategy moveStrategy)
        {
            _moveStrategy = moveStrategy;
        }

        public void Enter()
        {
            
        }

        public void Execute()
        {
            _moveStrategy.Move();
        }

        public void Exit()
        {
            
        }
    }
}

