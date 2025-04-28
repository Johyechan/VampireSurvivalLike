using Enemy.Boss.Interface;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossAttackState : BossStateBase
    {
        private IBossAttackStrategy _attackStrategy;

        public BossAttackState(Animator animator, int hash, IBossAttackStrategy attackStrategy) : base(animator, hash)
        {
            _attackStrategy = attackStrategy;
        }

        public override void Enter()
        {
            _animator.SetTrigger(_hash);
            _attackStrategy.RandomPattern();
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}

