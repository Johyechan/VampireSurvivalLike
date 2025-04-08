using Enemy.Interface;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyAttackState : IState
    {
        private Animator _animator;

        private int _hash;

        private IEnemyAttackStrategy _attackStrategy;

        public EnemyAttackState(Animator animator, int hash, IEnemyAttackStrategy attackStrategy)
        {
            _animator = animator;
            _hash = hash;
            _attackStrategy = attackStrategy;
        }

        public void Enter()
        {
            Debug.Log("Àû °ø°Ý");

            _attackStrategy.Attack();
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

