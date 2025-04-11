using Item.Interface;
using UnityEngine;

namespace Item.Strategy
{
    public class RangedWeaponStrategy : IWeaponStrategy
    {
        private float _damage;

        public RangedWeaponStrategy(float damage)
        {
            _damage = damage;
        }

        public GameObject Attack()
        {
            return null;
        }
    }
}