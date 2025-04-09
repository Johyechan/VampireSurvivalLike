using Enemy.Interface;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    public class EnemyMeleeAttack : EnemyAttackStrategyBase
    {
        private Transform _trans;

        private float _range;
        private float _damage;

        private string _layerMask;

        public EnemyMeleeAttack(Transform trans, float range, float damage, string layerMask)
        {
            _trans = trans;
            _range = range;
            _damage = damage;
            _layerMask = layerMask;
        }

        public override void Attack()
        {
            _damageable.TakeDamage(_damage);
        }

        public override bool CheckArea()
        {
            Collider2D hit = Physics2D.OverlapCircle(_trans.position, _range, LayerMask.GetMask(_layerMask));

            if (hit != null)
            {
                _damageable = hit.GetComponent<IDamageable>();
                return true;
            }

            return false;
        }
    }
}

