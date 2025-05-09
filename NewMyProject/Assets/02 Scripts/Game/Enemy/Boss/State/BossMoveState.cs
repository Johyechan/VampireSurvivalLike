using Enemy.Interface.Strategy;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossMoveState : BossStateBase
    {
        private IEnemyMoveStrategy _moveStrategy;

        public BossMoveState(Animator animator, int hash, IEnemyMoveStrategy moveStrategy) : base(animator, hash)
        {
            _moveStrategy = moveStrategy;
        }

        public override void Enter()
        {
            _animator.SetBool(_hash, true);
        }

        public override void Execute()
        {
            _moveStrategy.Move();
        }

        public override void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}

