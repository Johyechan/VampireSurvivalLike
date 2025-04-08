using Enemy.Interface;
using UnityEngine;

namespace Enemy.Strategy.Move
{
    public class EnemyPlayerFollowMove : IEnemyMoveStrategy
    {
        public bool CheckArea(Transform trans, float range, string layerMask)
        {
            Collider2D hit = Physics2D.OverlapCircle(trans.position, range, LayerMask.GetMask(layerMask));

            Debug.Log(hit);

            if(hit != null)
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

