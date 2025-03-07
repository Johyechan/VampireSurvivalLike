using Manager;
using MyInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectDecorator
{
    public class DotDamageDecorator : EffectDecoratorBase
    {
        private IDamageable _damageable;

        private float _duration;
        private float _damage;

        public DotDamageDecorator(IEffect effect, IDamageable damageable, float duration, float damage) : base(effect)
        {
            _damageable = damageable;
        }

        public override void ApplyEffect()
        {
            _effect.ApplyEffect();

            GameManager.Instance.StartCoroutine(DotDamage());
        }

        private IEnumerator DotDamage()
        {
            float currentTime = 0;
            while (currentTime < _duration)
            {
                _damageable.TakeDamage(_damage);
                currentTime += 1.0f;
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}

