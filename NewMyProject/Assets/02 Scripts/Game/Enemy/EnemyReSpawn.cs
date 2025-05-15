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
        private float _needReSpawnDistance;

        // �����ڿ��� ���� �ʱ�ȭ
        public EnemyReSpawn(Transform enemyTrans, float distance, float needReSpawnDistance)
        {
            _enemyTrans = enemyTrans;
            _distance = distance;
            _needReSpawnDistance = needReSpawnDistance;
        }

        // �罺�� �ؾ� �ϴ� ��Ȳ���� �Ǵ��ϴ� �Լ�
        public bool ReSpawnCheck()
        {
            float distance = Vector2.Distance(GameManager.Instance.player.transform.position, _enemyTrans.position); // �÷��̾�� �� ���� �Ÿ�
            Debug.Log(distance);

            if(distance >= _needReSpawnDistance) // ���� ������ �Ÿ��� �罺�� �ؾ��ϴ� �Ÿ� �̻��̶��
            {
                if(GameManager.Instance.PlayerMoveDir != Vector2.zero) // �׸��� �÷��̾ �����̰� �ִٸ�
                {
                    return true; // �罺�� �ض�
                }
            }

            return false; // �罺�� ���� ��
        }

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
