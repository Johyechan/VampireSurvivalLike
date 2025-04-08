using Enemy.Interface;
using UnityEngine;

namespace Enemy.Strategy.Move
{
    public class EnemyPlayerFollowMove : IEnemyMoveStrategy
    {
        public bool CheckArea(Transform trans, float range, string layerMask)
        {
            RaycastHit2D hit = Physics2D.CircleCast(trans.position, range, Vector2.zero, 0, LayerMask.GetMask(layerMask));

            if(hit.collider != null)
            {
                return true;
            }

            return false;
        }

        public void Move(Transform trans, Vector2 dir, float speed)
        {
            trans.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }
}

