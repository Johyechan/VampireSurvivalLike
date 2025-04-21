using Item.Effect;
using Item.Strategy;
using UnityEngine;

namespace Item.Weapon.Ranged
{
    public class RangedWeapon : WeaponItem
    {
        protected virtual void Awake()
        {
            _weaponStrategy = new RangedWeaponStrategy(transform, itemSO.range, "Enemy", this, itemSO.fireSpeed, itemSO.projectileType, itemSO.role);

            EffectContainer = new ItemEffectContainer();
        }

        protected virtual void Update()
        {
            LookCloseEnemy();
        }
    }
}

