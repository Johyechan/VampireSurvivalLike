using Manager;
using UnityEngine;

namespace Enemy
{
    // �ۼ���: ������
    // ���� ���� ���� �÷��̾�� �ʹ� �������� �� �÷��̾� �̵� �������� �罺���ϴ� ����� ����ϴ� Ŭ����
    public class EnemyReSpawn
    {
        private Transform _enemyTrans; // �� Transform
        private float _distance; // �÷��̾�κ��� �󸶳� ��������

        // �����ڿ��� ���� �ʱ�ȭ
        public EnemyReSpawn(Transform enemyTrans, float distance)
        {
            _enemyTrans = enemyTrans;
            _distance = distance;
        }

        //public bool ReSpawnCheck()
        //{

        //}

        // �罺�� �ϴ� �Լ�
        public void ReSpawn()
        {
            Vector2 moveDir = GameManager.Instance.PlayerMoveDir.normalized; // �÷��̾ �̵��ϴ� ����
            float angle = Random.Range(-30f, 30f); // �����ϰ� ȸ����ų ��
            Quaternion rotation = Quaternion.Euler(0, 0, angle); // ������ ȸ�� ��
            Vector2 spawDir = rotation * moveDir; // �÷��̾ �����̴� ���⿡�� -30�� ~ 30�� ������ ������ ������ ��ġ�� ���� ����
            Vector2 reSpawnPos = (Vector2)GameManager.Instance.player.transform.position + spawDir * _distance; // �÷��̾� ��ġ�������� _distance��ŭ ������ ���� ����

            _enemyTrans.position = reSpawnPos; // ���� ���� �������� �ű�
        }
    }
}
// ������ �ۼ� ����: 2025.05.15
