using UnityEngine;

namespace Enemy.Interface.Strategy
{
    // ���� �̵� ������ �����ϴ� �������̽�
    // �پ��� �̵� ����� �����ϰ� Ȯ���� �� �ֵ��� �Ѵ�
    public interface IEnemyMoveStrategy
    {
        // ���� ���� �ȿ� ���Դ��� Ȯ���ϴ� �Լ�
        public bool CheckArea();

        // ���� �̵��� �����ϴ� �Լ�
        // ����ü�� ���� ���󰡱�, �����ϱ� �� �پ��� ������� ������ �� ����
        public void Move();
    }
}

