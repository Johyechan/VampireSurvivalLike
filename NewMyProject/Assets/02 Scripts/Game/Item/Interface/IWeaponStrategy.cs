using UnityEngine;

namespace Item.Interface
{
    public interface IWeaponStrategy
    {
        public GameObject CheckArea();

        public void Attack();
    }
}