using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossDeathState : BossStateBase
    {
        public BossDeathState(Animator animator, int hash) : base(animator, hash)
        {
        }

        public override void Enter()
        {
            Debug.Log("»ç¸Á »óÅÂ");
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

