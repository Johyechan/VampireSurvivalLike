using Enemy;
using UnityEngine;

namespace Item.Effect
{
    public interface IItemEffect
    {
        public void Effect(EnemyBase enemy = null);

        public void RemoveEffect();
    }
}

