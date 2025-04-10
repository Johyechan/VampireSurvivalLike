using MyUtil.FSM;
using UnityEngine;

namespace Player.State
{
    public class PlayerDeathState : IState
    {
        private Animator _animator;

        private int _hash;

        public PlayerDeathState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        public void Enter()
        {
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

