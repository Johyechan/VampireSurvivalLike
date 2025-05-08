using MyUtil.FSM;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyDeathState : IState
    {
        // 사망 애니메이션을 실행하기 위한 애니메이터 변수
        private Animator _animator;

        // 사망 애니메이션을 실행하기 위한 해시 변수
        private int _hash;

        // 위에 변수들에 필요한 값들을 받아서 할당
        public EnemyDeathState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        // 이 상태에 들어왔을 때
        public void Enter()
        {
            // 애니메이션 실행
            Debug.Log("적 사망");
            _animator.SetTrigger(_hash);
        }

        // 이 상태인 동안
        public void Execute()
        {
            
        }

        // 이 상태에서 빠져나갈 때
        public void Exit()
        {
            
        }
    }
}

