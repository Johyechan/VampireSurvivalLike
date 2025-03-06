using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedIncreaseDecorator : EffectDecoratorBase
{
    public AttackSpeedIncreaseDecorator(INewEffect effect) : base(effect) { }

    public override void ApplyEffect()
    {
        _effect.ApplyEffect();

        Debug.Log("���� �ӵ� ����");
    }
}
