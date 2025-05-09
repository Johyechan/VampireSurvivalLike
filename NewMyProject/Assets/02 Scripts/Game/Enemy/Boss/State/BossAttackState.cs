using Enemy.Boss.Interface;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossAttackState : IState
    {
        private IBossAttackStrategy _attackStrategy;

        public BossAttackState(IBossAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        public void Enter()
        {
            _attackStrategy.Pattern();
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

