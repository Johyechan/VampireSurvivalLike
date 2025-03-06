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

        Debug.Log("�ƹ� ȿ�� ����");
    }

    public INewEffect GetBaseEffect()
    {
        return _effect;
    }
}
