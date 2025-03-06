using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDamageDecorator : EffectDecoratorBase
{
    public DotDamageDecorator(INewEffect effect) : base(effect) { }

    public override void ApplyEffect()
    {
        _effect.ApplyEffect();

        Debug.Log("도트 데미지");
    }
}
