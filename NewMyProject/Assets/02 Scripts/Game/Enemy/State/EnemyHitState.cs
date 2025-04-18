using Manager;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyHitState : IState
    {
        // 공격 당했을 때 애니메이션을 실행 시키기 위한 애니메이터 변수
        private Animator _animator;

        // 애니메이션을 실행 시키기 위한 해시 변수
        private int _hash;

        // 생성장에서 위에 변수에 필요한 값들을 받아서 할당
        public EnemyHitState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        // 이 상태에 들어왔을 때
        public void Enter()
        {
            // 애니메이션 실행
            _animator.SetTrigger(_hash);
        }

        // 이 상태인 동안
        public void Execute()
        {

        }

        // 이 상태에서 빠져 나갈 때
        public void Exit()
        {
            
        }
    }
}

