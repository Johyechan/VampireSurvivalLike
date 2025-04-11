using Item.Interface;
using UnityEngine;

namespace Item.Strategy
{
    public class MeleeWeaponStrategy : IWeaponStrategy
    {
        public GameObject Attack()
        {
            return null;
        }

        public GameObject CheckArea()
        {
            throw new System.NotImplementedException();
        }
    }
}