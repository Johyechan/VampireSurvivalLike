using MyInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectDecorator
{
    public abstract class EffectDecoratorBase : IEffect
    {
        protected IEffect _effect;

        public EffectDecoratorBase(IEffect effect)
        {
            _effect = effect;
        }

        public abstract void ApplyEffect(GameObject enemy);

        public IEffect GetBaseEffect()
        {
            return _effect;
        }
    }
}

