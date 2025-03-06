using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDecoratorBase : INewEffect
{
    protected INewEffect _effect;

    public EffectDecoratorBase(INewEffect effect)
    {
        _effect = effect;
    }

    public virtual void ApplyEffect()
    {
        _effect.ApplyEffect();

        Debug.Log("아무 효과 없음");
    }

    public INewEffect GetBaseEffect()
    {
        return _effect;
    }
}
