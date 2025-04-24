using Enemy.Interface;
using Enemy.Interface.Strategy;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // 일반 적의 공격 상태 전환을 처리하는 클래스
    public class NormalAttackStateTransition : ITransition
    {
        private StateMachine _machine;

        private IState _attackState;

        private EnemyBaseVariables _enemyVariables;

        private IEnemyAttackStrategy _attackStrategy;

        public NormalAttackStateTransition(StateMachine machine, IState attackState, EnemyBaseVariables enemyVariables, IEnemyAttackStrategy attackStrategy)
        {
            _machine = machine;
            _attackState = attackState;
            _enemyVariables = enemyVariables;
            _attackStrategy = attackStrategy;
        }

        // 공격 상태로 전환 가능한지 판단하는 메서드
        public bool TryTransitionToThisState()
        {
            // 공격 범위 안에 있고 공격 중이 아닐 경우 true 반환 및 상태 변화
            if (_attackStrategy.CheckArea())
            {
                if (!_enemyVariables.IsAttackDelay)
                {
                    _enemyVariables.IsAttackDelay = true;
                    _machine.ChangeState(_attackState);
                    return true;
                }
            }

            return false;
        }
    }
}

