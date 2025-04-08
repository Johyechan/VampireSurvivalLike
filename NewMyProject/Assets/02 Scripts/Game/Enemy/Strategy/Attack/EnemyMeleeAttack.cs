using Enemy.Interface;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    public class EnemyMeleeAttack : EnemyAttackStrategyBase
    {
        private float _damage;

        public EnemyMeleeAttack(float damage)
        {
            _damage = damage;
        }

        public override void Attack()
        {
            _damageable.TakeDamage(_damage);
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

