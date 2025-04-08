using Enemy.Interface;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    public class EnemyRangedAttack : EnemyAttackStrategyBase
    {
        public override void Attack()
        {
            
        }

        public override bool CheckArea(Transform trans, float range, string layerMask)
        {
            RaycastHit2D hit = Physics2D.CircleCast(trans.position, range, Vector2.zero, 0, LayerMask.GetMask(layerMask));

            if (hit.collider != null)
            {
                _damageable = hit.collider.GetComponent<IDamageable>();
                return true;
            }

            return false;
        }
    }
}

