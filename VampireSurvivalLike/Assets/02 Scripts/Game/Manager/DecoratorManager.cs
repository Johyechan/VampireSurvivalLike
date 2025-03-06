using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorManager : MonoSingleton<DecoratorManager>
{
    public INewEffect RemoveEffect<T>(INewEffect effect) where T : EffectDecoratorBase
    {
        if(effect is T)
        {
            return ((EffectDecoratorBase)effect).GetBaseEffect();
        }
        else if(effect is EffectDecoratorBase decorator)
        {
            INewEffect newEffect = RemoveEffect<T>(decorator.GetBaseEffect());
            if(newEffect != decorator.GetBaseEffect())
            {
                Debug.Log($"{typeof(T).Name} 효과가 없음");
            }
        }

        return effect;
    }
}
