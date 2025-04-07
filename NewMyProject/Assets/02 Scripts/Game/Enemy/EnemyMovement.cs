using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public bool CheckArea(float range)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, range, Vector2.zero, 0, LayerMask.GetMask("Player"));

            if(hit.collider != null)
            {
                return true;
            }

            return false;
        }

        public void Move(Vector2 dir, float speed)
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }
}

