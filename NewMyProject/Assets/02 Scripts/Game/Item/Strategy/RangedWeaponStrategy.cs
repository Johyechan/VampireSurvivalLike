using Item.Interface;
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
        private float _attackSpeed;

        private ObjectPoolType _projectileType;

        public RangedWeaponStrategy(Transform trans, float range, string layerMask, float damage, float attackSpeed, ObjectPoolType projectileType)
        {
            _trans = trans;
            _range = range;
            _layerMask = layerMask;
            _damage = damage;
            _attackSpeed = attackSpeed;
            _projectileType = projectileType;
        }

        public GameObject Attack()
        {
            GameObject enemy = CheckArea();
            if(enemy != null)
            {
                GameObject bullet = ObjectPoolManager.Instance.GetObject(_projectileType);
            }
            
            return null;
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