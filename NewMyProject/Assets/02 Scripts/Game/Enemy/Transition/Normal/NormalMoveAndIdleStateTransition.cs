using Enemy.Interface;
using Enemy.Interface.Strategy;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // 일반 적의 움직임 또는 대기 상태 전환을 처리하는 클래스
    public class NormalMoveAndIdleStateTransition : ITransition
    {
        private StateMachine _machine;

        private IEnemyMoveStrategy _moveStrategy;

        private IState _moveState;

        private IState _idleState;

        public NormalMoveAndIdleStateTransition(StateMachine machine, IEnemyMoveStrategy moveStrategy, IState moveState, IState idleState)
        {
            _machine = machine;
            _moveStrategy = moveStrategy;
            _moveState = moveState;
            _idleState = idleState;
        }

        // 전환이 가능한지 판단하는 메서드
        public bool TryTransitionToThisState()
        {
            // 움직임 범위 안에 플레이어가 있는지 확인
            if (_moveStrategy.CheckArea())
            {
                // 현재 상태가 움직임 상태가 아닐 경우 움직임 상태로 전환 및 true 반환
                if (!_machine.IsCurrentState(_moveState))
                {
                    _machine.ChangeState(_moveState);
                    return true;
                }
            }
            else // 범위 안에 플레이어가 없다면 대기 상태로 전환 및 true 반환
            {
                _machine.ChangeState(_idleState);
                return true;
            }

            return false;
        }
    }
}

