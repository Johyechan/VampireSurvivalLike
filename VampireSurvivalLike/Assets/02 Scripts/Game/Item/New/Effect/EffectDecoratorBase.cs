using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectDecoratorBase : INewEffect
{
    protected INewEffect _effect;

    public EffectDecoratorBase(INewEffect effect)
    {
        _effect = effect;
    }

    public abstract void ApplyEffect();

    public INewEffect GetBaseEffect()
    {
        return _effect;
    }
}
