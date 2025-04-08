using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyIdleState : IState
    {
        private Animator _animator;

        private int _hash;

        public EnemyIdleState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        public void Enter()
        {
            Debug.Log("적 기본 상태");

            _animator.SetTrigger(_hash);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

