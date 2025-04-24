using Enemy.Interface;
using Enemy.Projectile;
using Manager;
using MyUtil;
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
            // 플레이어로 향하는 방향 구하기
            Vector2 dir = GameManager.Instance.player.transform.position - _trans.position;

            // 플레이어를 바라보는 방향 구하기
            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

            // 발사체 생성
            GameObject projectile = ObjectPoolManager.Instance.GetObject(_type);

            EnemyProjectile enemyProjectile = projectile.GetComponent<EnemyProjectile>();

            // 발사체 초기화
            projectile.transform.position = _trans.position;
            projectile.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            enemyProjectile.Damage = _damage;
            enemyProjectile.Direction = dir.normalized;
            enemyProjectile.FireSpeed = _fireSpeed;
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

