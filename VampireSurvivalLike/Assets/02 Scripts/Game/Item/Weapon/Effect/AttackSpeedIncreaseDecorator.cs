using Manager;
using MyInterface;
using MyStat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectDecorator
{
    public class AttackSpeedIncreaseDecorator : EffectDecoratorBase
    {
        private float _increaseValue;

        public AttackSpeedIncreaseDecorator(IEffect effect, float increaseValue) : base(effect)
        {
            _increaseValue = increaseValue;
        }

        public override void ApplyEffect()
        {
            _effect.ApplyEffect();

            ItemStat stat = StatManager.Instance.TotalItemStat;
            stat.attackSpeed += _increaseValue;
            StatManager.Instance.TotalItemStat = stat;
        }
    }
}

