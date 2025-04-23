using UnityEngine;

namespace Item.Interface
{
    public interface IWeaponStrategy
    {
        public void Attack(GameObject enemy = null);
    }
}