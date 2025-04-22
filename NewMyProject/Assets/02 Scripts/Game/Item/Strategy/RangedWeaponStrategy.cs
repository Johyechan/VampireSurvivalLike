using Item.Interface;
using Item.Weapon;
using Item.Weapon.Ranged;
using Manager;
using MyUtil;
using MyUtil.Pool;
using NPOI.OpenXmlFormats.Dml;
using Player.Enum;
using UnityEngine;

namespace Item.Strategy
{
    public class RangedWeaponStrategy : IWeaponStrategy
    {
        private Transform _trans;

        private RangedWeapon _weapon;

        private string _layerMask;

        private float _range;
        private float _fireSpeed;
        private float _damage;

        private ObjectPoolType _projectileType;

        private RoleType _roleType;

        public RangedWeaponStrategy(Transform trans, float range, string layerMask, RangedWeapon weapon, float fireSpeed, ObjectPoolType projectileType, RoleType roleType)
        {
            _trans = trans;
            _range = range;
            _layerMask = layerMask;
            _weapon = weapon;
            _fireSpeed = fireSpeed;
            _projectileType = projectileType;
            _roleType = roleType;
        }

        public void Attack()
        {
            GameObject enemy = _weapon.CheckArea(_trans, _range, _layerMask);
            if(enemy != null)
            {
                GameObject projectile = ObjectPoolManager.Instance.GetObject(_projectileType);

                ProjectileBase projectileBase = projectile.GetComponent<ProjectileBase>();

                Vector2 dir = enemy.transform.position - _trans.transform.position;

                float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

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
    }
}