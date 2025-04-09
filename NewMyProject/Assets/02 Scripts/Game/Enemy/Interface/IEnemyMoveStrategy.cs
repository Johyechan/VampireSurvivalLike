using UnityEngine;

namespace Enemy.Interface
{
    // �������� (�÷��̾ ����ٴϱ⸸ �ϴ� ������, ��Ʈ�� ������) ������ ���� �������̽�
    public interface IEnemyMoveStrategy
    {
        // ������ �÷��̾ �ִ��� üũ�ϴ� �Լ�
        public bool CheckArea(Transform trans, float range, string layerMask);

        // �����̴� �Լ�
        public void Move(Transform trans, Vector2 dir, float speed);
    }
}

