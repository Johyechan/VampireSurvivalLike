using MyUtil.FSM;
using UnityEngine;

namespace Player.State
{
    public class PlayerMoveState : IState
    {
        private Animator _animator;

        private int _hash;

        public PlayerMoveState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        public void Enter()
        {
            _animator.SetBool(_hash, true);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}
