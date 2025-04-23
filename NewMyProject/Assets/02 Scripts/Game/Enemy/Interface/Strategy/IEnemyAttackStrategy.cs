using UnityEngine;

namespace Enemy.Interface.Strategy
{
    // ���� ���� ������ �����ϴ� �������̽�
    // �پ��� ���� ���� ����� �����ϰ� Ȯ���� �� �ֵ��� �Ѵ�
    public interface IEnemyAttackStrategy
    {
        // ���� ������ ���� ���� ����� �ִ��� Ȯ���ϴ� �Լ�
        // ���� ������ ����� �����ϸ� true, �ƴϸ� false
        public bool CheckArea();

        // ���� ������ �����ϴ� �Լ�
        // ����ü�� ���� ����, ���Ÿ� �� �پ��� ������� ������ �� ����
        public void Attack();
    }
}

