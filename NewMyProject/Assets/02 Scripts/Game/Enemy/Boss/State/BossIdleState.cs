using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossIdleState : BossStateBase
    {
        public BossIdleState(Animator animator, int hash) : base(animator, hash)
        {

        }

        public override void Enter()
        {
            _animator.SetBool(_hash, true);
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}

