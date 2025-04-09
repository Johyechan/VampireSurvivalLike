using Enemy.Interface;
using UnityEngine;

namespace Enemy.Strategy.Move
{
    // �÷��̾ ����ٴϴ� ������
    public class EnemyPlayerFollowMove : IEnemyMoveStrategy
    {
        public bool CheckArea(Transform trans, float range, string layerMask)
        {
            // ���� ���� ���� �� �÷��̾� ã��
            Collider2D hit = Physics2D.OverlapCircle(trans.position, range, LayerMask.GetMask(layerMask));

            Debug.Log(hit);

            // ã�Ҵٸ� true�� ��ȯ
            if(hit != null)
            {
                return true;
            }

            // ã�� ���ߴٸ� false�� ��ȯ
            return false;
        }

        public void Move(Transform trans, Vector2 dir, float speed)
        {
            // trans�� dir �������� speed�� �ӵ��� ������
            trans.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }
}

