using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyIdleState : IState
    {
        // idle 애니메이션을 실행시키기 위한 animator 변수
        private Animator _animator;

        // idle 애니메이션을 실행시키기 위한 해시 변수
        private int _hash;

        // 위의 변수들을 초기화 해주기 위한 생성자
        public EnemyIdleState(Animator animator, int hash)
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

        // 이 상태에서 빠져 나올 때
        public void Exit()
        {
            
        }
    }
}

