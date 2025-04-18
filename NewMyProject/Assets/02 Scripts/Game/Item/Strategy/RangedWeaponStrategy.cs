using Item.Interface;
using Manager;
using MyUtil.Pool;
using NPOI.OpenXmlFormats.Dml;
using Player.Enum;
using UnityEngine;

namespace Item.Strategy
{
    public class RangedWeaponStrategy : IWeaponStrategy
    {
        private Transform _trans;

        private string _layerMask;

        private float _range;
        private float _fireSpeed;
        private float _damage;

        private ObjectPoolType _projectileType;

        private RoleType _roleType;

        public RangedWeaponStrategy(Transform trans, float range, string layerMask, float fireSpeed, ObjectPoolType projectileType, RoleType roleType)
        {
            _trans = trans;
            _range = range;
            _layerMask = layerMask;
            _fireSpeed = fireSpeed;
            _projectileType = projectileType;
            _roleType = roleType;
        }

        public void Attack()
        {
            GameObject enemy = CheckArea();
            if(enemy != null)
            {
                GameObject projectile = ObjectPoolManager.Instance.GetObject(_projectileType);

                ProjectileBase projectileBase = projectile.GetComponent<ProjectileBase>();

                Vector2 dir = enemy.transform.position - _trans.transform.position;

                float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

                _trans.rotation = Quaternion.Euler(0, 0, angle - 90);
                projectile.transform.position = _trans.position;
                projectile.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

                switch(_roleType)
                {
                    case RoleType.Reaper:
                        _damage = StatManager.Instance.AllStat.soulPower + StatManager.Instance.PlayerStat.damage;
                        break;
                    case RoleType.Magician:
                        _damage = StatManager.Instance.AllStat.abilityPower + StatManager.Instance.PlayerStat.damage;
                        break;
                    default:
                        _damage = StatManager.Instance.AllStat.attackDamage + StatManager.Instance.PlayerStat.damage;
                        break;
                }

                projectileBase.Damage = _damage;
                projectileBase.FireSpeed = _fireSpeed;
                projectileBase.Direction = dir;
            }
        }

        public GameObject CheckArea()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(_trans.position, _range, LayerMask.GetMask(_layerMask));
            float distance = float.MaxValue;
            GameObject returnObj = null;

            if(hits.Length > 0)
            {
                for(int i = 0; i < hits.Length; i++)
                {
                    float checkDistance = Vector2.Distance(_trans.position, hits[i].transform.position);
                    if (distance > checkDistance)
                    {
                        distance = checkDistance;
                        returnObj = hits[i].gameObject;
                    }
                }
            }

            return returnObj;
        }
    }
}