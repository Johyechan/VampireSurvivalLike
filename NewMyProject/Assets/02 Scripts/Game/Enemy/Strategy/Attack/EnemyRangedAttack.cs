using Enemy.Interface;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    public class EnemyRangedAttack : EnemyAttackStrategyBase
    {
        private Transform _trans;

        private float _range;
        private float _damage;

        private string _layerMask;

        public EnemyRangedAttack(Transform trans, float range, float damage, string layerMask)
        {
            _trans = trans;
            _range = range;
            _damage = damage;
            _layerMask = layerMask;
        }

        public override void Attack()
        {
            
        }

        public override bool CheckArea()
        {
            RaycastHit2D hit = Physics2D.CircleCast(_trans.position, _range, Vector2.zero, 0, LayerMask.GetMask(_layerMask));

            if (hit.collider != null)
            {
                _damageable = hit.collider.GetComponent<IDamageable>();
                return true;
            }

            return false;
        }
    }
}

