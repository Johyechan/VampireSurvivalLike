using UnityEngine;

namespace Enemy.Interface
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

