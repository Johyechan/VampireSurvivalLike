using Enemy.Interface;
using Enemy.Projectile;
using Manager;
using MyUtil.Interface;
using MyUtil.Pool;
using Unity.Cinemachine;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    public class EnemyRangedAttack : EnemyAttackStrategyBase
    {
        private Transform _trans;

        private ObjectPoolType _type;

        private float _range;
        private float _damage;
        private float _fireSpeed;

        private string _layerMask;

        public EnemyRangedAttack(Transform trans, float range, float damage, string layerMask, ObjectPoolType fireType, float fireSpeed)
        {
            _trans = trans;
            _range = range;
            _damage = damage;
            _layerMask = layerMask;
            _type = fireType;
            _fireSpeed = fireSpeed;
        }

        public override void Attack()
        {
            Vector2 dir = GameManager.Instance.player.transform.position - _trans.position;

            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

            GameObject projectile = ObjectPoolManager.Instance.GetObject(_type);

            EnemyProjectile enemyProjectile = projectile.GetComponent<EnemyProjectile>();

            projectile.transform.position = _trans.position;
            projectile.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            enemyProjectile.Damage = _damage;
            enemyProjectile.Direction = dir.normalized;
            enemyProjectile.FireSpeed = _fireSpeed;
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

