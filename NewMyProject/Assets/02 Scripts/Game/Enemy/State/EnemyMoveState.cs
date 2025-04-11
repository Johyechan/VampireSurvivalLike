using Enemy.Interface;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyMoveState : IState
    {
        // move 애니메이션을 실행 시키기 위한 animator 변수
        private Animator _animator;

        // move 애니메이션을 실행 시키기 위한 해시 변수
        private int _hash;

        // 움직임 전략 변수 (플레이어 따라다니는 움직임 또는 패트롤 움직임 (더 많은 종류가 생길 수 있음)
        private IEnemyMoveStrategy _moveStrategy;

        // 위의 변수들을 생성자에서 할당
        public EnemyMoveState(Animator animator, int hash, IEnemyMoveStrategy moveStrategy)
        {
            _animator = animator;
            _hash = hash;
            _moveStrategy = moveStrategy;
        }

        // 이 상태에 들어왔을 때
        public void Enter()
        {
            // 움직임 애니메이션 실행
            _animator.SetBool(_hash, true);
        }

        // 이 상태인 동안
        public void Execute()
        {
            // 움직임 전략에 따라 움직이기
            _moveStrategy.Move();
        }

        // 이 상태에서 빠져나올 때
        public void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}

