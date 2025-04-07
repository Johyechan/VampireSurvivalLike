using Enemy.Interface;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Strategy
{
    public abstract class EnemyAttackStrategyBase : IEnemyAttackStrategy
    {
        protected IDamageable _damageable;

        private bool CheckArea(Transform trans, float range)
        {
            RaycastHit2D hit = Physics2D.CircleCast(trans.position, range, Vector2.zero, 0, LayerMask.GetMask("Player"));

            if(hit.collider != null)
            {
                _damageable = hit.collider.GetComponent<IDamageable>();
                return true;
            }

            return false;
        }

        protected bool IsPlayerInArea(Transform trans, float range)
        {
            return CheckArea(trans, range);
        }

        public abstract void Attack();
    }
}

