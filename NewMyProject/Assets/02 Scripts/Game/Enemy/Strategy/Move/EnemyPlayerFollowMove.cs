using Enemy.Interface;
using UnityEngine;

namespace Enemy.Strategy.Move
{
    // 플레이어를 따라다니는 움직임
    public class EnemyPlayerFollowMove : IEnemyMoveStrategy
    {
        public bool CheckArea(Transform trans, float range, string layerMask)
        {
            // 일정 원형 범위 내 플레이어 찾기
            Collider2D hit = Physics2D.OverlapCircle(trans.position, range, LayerMask.GetMask(layerMask));

            Debug.Log(hit);

            // 찾았다면 true를 반환
            if(hit != null)
            {
                return true;
            }

            // 찾지 못했다면 false를 반환
            return false;
        }

        public void Move(Transform trans, Vector2 dir, float speed)
        {
            // trans를 dir 방향으로 speed의 속도로 움직임
            trans.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }
}

