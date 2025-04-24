using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // 일반 적의 넉백 상태 전환을 처리하는 클래스
    public class NormalKnockbackTransition : ITransition
    {
        private EnemyBaseVariables _enemyVariables;

        public NormalKnockbackTransition(EnemyBaseVariables enemyVariables)
        {
            _enemyVariables = enemyVariables;
        }

        // 넉백상태로 전환 가능한지 판단하는 메서드
        public bool TryTransitionToThisState()
        {
            // 적이 넉백 상태면 전환
            if(_enemyVariables.Isknockback)
            {
                return true;
            }

            return false;
        }
    }
}

