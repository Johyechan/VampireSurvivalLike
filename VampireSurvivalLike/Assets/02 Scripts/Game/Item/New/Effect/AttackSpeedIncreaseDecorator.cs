using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedIncreaseDecorator : EffectDecoratorBase
{
    public AttackSpeedIncreaseDecorator(INewEffect effect) : base(effect) { }

    public override void ApplyEffect()
    {
        base.ApplyEffect();

        Debug.Log("���� �ӵ� ����");
    }
}
