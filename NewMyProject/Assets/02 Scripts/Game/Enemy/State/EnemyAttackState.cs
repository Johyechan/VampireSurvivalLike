using Enemy.Interface;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyAttackState : EnemyStateBase
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

        public override void Enter()
        {
            base.Enter();

            _attackStrategy.Attack();
            _animator.SetTrigger(_hash);
        }
    }
}

