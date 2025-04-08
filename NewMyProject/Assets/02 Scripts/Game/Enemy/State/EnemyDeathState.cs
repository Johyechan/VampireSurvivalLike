using MyUtil.FSM;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyDeathState : IState
    {
        private Animator _animator;

        private int _hash;

        public EnemyDeathState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        public void Enter()
        {
            Debug.Log("Àû »ç¸Á");

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

