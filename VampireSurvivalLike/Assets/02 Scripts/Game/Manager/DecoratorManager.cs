using EffectDecorator;
using Manager;
using MyInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class DecoratorManager : MonoSingleton<DecoratorManager>
    {
        public IEffect RemoveEffect<T>(IEffect effect) where T : EffectDecoratorBase
        {
            if (effect is T)
            {
                return ((EffectDecoratorBase)effect).GetBaseEffect();
            }
            else if (effect is EffectDecoratorBase decorator)
            {
                IEffect newEffect = RemoveEffect<T>(decorator.GetBaseEffect());
                if (newEffect != decorator.GetBaseEffect())
                {
                    return Activator.CreateInstance(decorator.GetType(), newEffect) as IEffect;
                }
            }

            return effect;
        }
    }
}

