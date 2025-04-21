using Item.Interface;
using UnityEngine;

namespace Item.Weapon
{
    public class WeaponItem : ItemBase
    {
        protected IWeaponStrategy _weaponStrategy;

        private GameObject _closeEnemy;

        protected void LookCloseEnemy()
        {
            _closeEnemy = CheckArea(transform, 1000f, "Enemy");

            Vector2 dir = _closeEnemy.transform.position - transform.position;

            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
        }

        public GameObject CheckArea(Transform trans, float range, string layerMask)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(trans.position, range, LayerMask.GetMask(layerMask));
            float distance = float.MaxValue;
            GameObject returnObj = null;

            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    float checkDis = Vector2.Distance(trans.position, hits[i].transform.position);
                    if (distance > checkDis)
                    {
                        distance = checkDis;
                        returnObj = hits[i].gameObject;
                    }
                }
            }

            return returnObj;
        }
    }
}
