using Enemy.Interface;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // 일반 적의 피격 상태 전환을 처리하는 클래스
    public class NormalHitStateTransition : ITransition
    {
        private StateMachine _machine;

        private EnemyHealth _health;

        private IState _hitState;

        public NormalHitStateTransition(StateMachine machine, EnemyHealth health, IState hitState)
        {
            _machine = machine;
            _health = health;
            _hitState = hitState;
        }

        // 전환 가능한지 판단하는 메서드
        public bool TryTransitionToThisState()
        {
            // 피격 상태라면 상태 전환 및 true 반환 
            // 중복 상태 전환을 막기 위해 IsHit을 false로 변경
            if (_health.IsHit)
            {
                _machine.ChangeState(_hitState);
                _health.IsHit = false;
                return true;
            }

            return false;
        }
    }
}

