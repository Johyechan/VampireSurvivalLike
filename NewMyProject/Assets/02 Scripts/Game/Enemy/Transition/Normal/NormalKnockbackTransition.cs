using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // �Ϲ� ���� �˹� ���� ��ȯ�� ó���ϴ� Ŭ����
    public class NormalKnockbackTransition : ITransition
    {
        private EnemyBaseVariables _enemyVariables;

        public NormalKnockbackTransition(EnemyBaseVariables enemyVariables)
        {
            _enemyVariables = enemyVariables;
        }

        // �˹���·� ��ȯ �������� �Ǵ��ϴ� �޼���
        public bool TryTransitionToThisState()
        {
            // ���� �˹� ���¸� ��ȯ
            if(_enemyVariables.Isknockback)
            {
                return true;
            }

            return false;
        }
    }
}

