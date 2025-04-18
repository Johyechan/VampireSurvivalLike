using Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Effect
{
    public class ItemEffectContainer : IItemEffect
    {
        private List<IItemEffect> _effects = new();

        public void AddEffect(IItemEffect effect)
        {
            if(!_effects.Contains(effect))
            {
                _effects.Add(effect);
            }
        }

        public void RemoveEffect(IItemEffect effect) => _effects.Remove(effect);

        public void Effect(EnemyBase enemy = null)
        {
            foreach (var effect in _effects)
            {
                effect.Effect(enemy);
            }
        }
    }
}

