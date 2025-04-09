using Enemy.Interface;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyAttackState : IState
    {
        // 공격 애니메이션을 실행하기 위한 애니메이터 변수
        private Animator _animator;

        // 공격 애니메이션을 실행하기 위한 해시 변수
        private int _hash;

        // 공격 전략 변수로 근거리 또는 원거리
        private IEnemyAttackStrategy _attackStrategy;

        // 생성자에서 위에 필요한 값들을 받아서 할당
        public EnemyAttackState(Animator animator, int hash, IEnemyAttackStrategy attackStrategy)
        {
            _animator = animator;
            _hash = hash;
            _attackStrategy = attackStrategy;
        }

        // 이 상태에 들어왔을 때
        public void Enter()
        {
            Debug.Log("적 공격");

            // 전략에 맞는 공격 방식으로 공격 명령
            _attackStrategy.Attack();
            // 공격 애니메이션 실행
            _animator.SetTrigger(_hash);
        }

        // 이 상태인 동안
        public void Execute()
        {
            
        }

        // 이 상태에서 빠져 나올 때
        public void Exit()
        {
            
        }
    }
}

