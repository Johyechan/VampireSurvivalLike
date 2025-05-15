using UnityEngine;

namespace Enemy
{
    // ���� ������ �����ϱ� ���� Ŭ����
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

        // ���� ���� �ӵ��� �����ϴ� �޼���
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

