using MyUtil.FSM;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyDeathState : EnemyStateBase
    {
        private Animator _animator;

        private int _hash;

        public EnemyDeathState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        public override void Enter()
        {
            base.Enter();

            _animator.SetTrigger(_hash);
        }
    }
}

