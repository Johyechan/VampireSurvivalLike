using Item.Interface;
using Manager;
using MyUtil.Pool;
using NPOI.OpenXmlFormats.Dml;
using UnityEngine;

namespace Item.Strategy
{
    public class RangedWeaponStrategy : IWeaponStrategy
    {
        private Transform _trans;

        private string _layerMask;

        private float _range;
        private float _damage;
        private float _fireSpeed;

        private ObjectPoolType _projectileType;

        public RangedWeaponStrategy(Transform trans, float range, string layerMask, float damage, float fireSpeed, ObjectPoolType projectileType)
        {
            _trans = trans;
            _range = range;
            _layerMask = layerMask;
            _damage = damage;
            _fireSpeed = fireSpeed;
            _projectileType = projectileType;
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

                projectileBase.Damage = _damage;
                projectileBase.FireSpeed = _fireSpeed;
                projectileBase.Direction = dir;
            }
        }

        public GameObject CheckArea()
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(_trans.position, _range, LayerMask.GetMask(_layerMask));
            float distance = float.MaxValue;
            GameObject returnObj = null;

            if(hit.Length > 0)
            {
                for(int i = 0; i < hit.Length; i++)
                {
                    float checkDistance = Vector2.Distance(_trans.position, hit[i].transform.position);
                    if (distance > checkDistance)
                    {
                        distance = checkDistance;
                        returnObj = hit[i].gameObject;
                    }
                }
            }

            return returnObj;
        }
    }
}