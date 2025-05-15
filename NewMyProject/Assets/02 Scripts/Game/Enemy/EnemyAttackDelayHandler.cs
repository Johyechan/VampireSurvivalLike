using UnityEngine;

namespace Enemy
{
    // 연속 공격을 방지하기 위한 클래스
    public class EnemyAttackDelayHandler
    {
        private EnemySO _so;

        private EnemyBaseVariables _enemyVariables;

        private float _currentAttackDelayTime = 0;

        public EnemyAttackDelayHandler(EnemySO so, EnemyBaseVariables enemyVariables)
        {
            _so = so;
            _enemyVariables = enemyVariables;
        }

        // 적의 공격 속도를 결정하는 메서드
        public void AttackDelay()
        {
            _currentAttackDelayTime += Time.deltaTime;

            if (_currentAttackDelayTime > (1 / _so.attackSpeed))
            {
                _enemyVariables.IsAttackDelay = false;
                _currentAttackDelayTime = 0;
            }
        }
    }
}

