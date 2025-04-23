using Item.Interface;
using MyUtil;
using UnityEngine;

namespace Item.Weapon
{
    public class WeaponItem : ItemBase
    {
        protected IWeaponStrategy _weaponStrategy;

        private GameObject _closeEnemy;

        protected void LookCloseEnemy()
        {
            _closeEnemy = AreaUtil.CheckCloseTargetInArea(transform, 1000f, LayerMask.GetMask("Enemy"));

            Vector2 dir = _closeEnemy.transform.position - transform.position;

            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}
