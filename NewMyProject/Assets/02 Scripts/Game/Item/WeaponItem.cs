using Item.Interface;
using UnityEngine;

namespace Item.Weapon
{
    public class WeaponItem : ItemBase
    {
        protected IWeaponStrategy _weaponStrategy;

        public bool IsAttackEnd { get; set; }
    }
}
