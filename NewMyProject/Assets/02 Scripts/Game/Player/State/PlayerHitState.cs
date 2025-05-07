using MyUtil.FSM;
using UnityEngine;

namespace Player.State
{
    public class PlayerHitState : IState
    {
        private Animator _animator;

        private int _hash;

        public PlayerHitState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        public void Enter()
        {
            Debug.Log("dd");
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

