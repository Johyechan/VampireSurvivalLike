using Enemy.Interface;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;
using UnityEngine.Rendering;

namespace Enemy.Transition.Normal
{
    // 일반 적의 사망 상태 전환을 처리하는 클래스
    public class NormalDeathStateTransition : ITransition
    {
        private StateMachine _machine;

        private EnemyHealth _health;

        private IState _deathState;

        public NormalDeathStateTransition(StateMachine machine, EnemyHealth health, IState deathState)
        {
            _machine = machine;
            _health = health;
            _deathState = deathState;
        }

        // 상태 전환이 가능한지 판단하는 메서드
        public bool TryTransitionToThisState()
        {
            // 사망 상태이면서 죽음 상태가 아닐 경우 상태 변환 및 true 반환
            if (_health.IsDie)
            {
                if (!_machine.IsCurrentState(_deathState))
                {
                    _machine.ChangeState(_deathState);
                }
                return true;
            }
            return false;
        }
    }
}

