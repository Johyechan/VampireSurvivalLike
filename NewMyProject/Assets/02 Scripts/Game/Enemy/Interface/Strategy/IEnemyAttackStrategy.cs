using UnityEngine;

namespace Enemy.Interface.Strategy
{
    // ���� ����� ���� ������� ���� �� �ִٰ� �����Ͽ�
    // Ȯ�强�� �ø��� ���� ���� ������ ����
    // �׷��� �� �������̽��� �����ϴ� Ŭ������ ����� ���� ������ ���� ����� �ʿ信 ���� �߰��� ����
    public interface IEnemyAttackStrategy
    {
        public bool CheckArea();

        public void Attack();
    }
}

