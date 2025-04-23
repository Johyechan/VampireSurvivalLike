using Enemy.Interface;
using MyUtil;
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
            GameObject player = AreaUtil.CheckArea(_trans, _range, LayerMask.GetMask(_layerMask));

            if (player != null)
                return true;

            return false;
        }
    }
}

