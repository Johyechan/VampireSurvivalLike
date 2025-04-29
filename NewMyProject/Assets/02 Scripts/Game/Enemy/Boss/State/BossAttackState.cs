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
            Debug.Log("공격 상태");
            _attackStrategy.RandomPattern();
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

