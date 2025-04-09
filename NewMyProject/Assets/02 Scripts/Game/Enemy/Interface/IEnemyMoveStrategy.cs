using UnityEngine;

namespace Enemy.Interface
{
    // �������� (�÷��̾ ����ٴϱ⸸ �ϴ� ������, ��Ʈ�� ������) ������ ���� �������̽�
    public interface IEnemyMoveStrategy
    {
        // ������ �÷��̾ �ִ��� üũ�ϴ� �Լ�
        public bool CheckArea();

        // �����̴� �Լ�
        public void Move();
    }
}

