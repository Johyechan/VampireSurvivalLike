using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossHitState : BossStateBase
    {
        public BossHitState(Animator animator, int hash) : base(animator, hash)
        {
        }

        public override void Enter()
        {
            Debug.Log("�ǰ� ����");
            _animator.SetTrigger(_hash);
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}

