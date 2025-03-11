using Manager;
using MyInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectDecorator
{
    public class DotDamageDecorator : EffectDecoratorBase
    {
        private float _duration;
        private float _damage;

        public DotDamageDecorator(IEffect effect, float duration, float damage) : base(effect)
        {
            _duration = duration;
            _damage = damage;
        }

        public override void ApplyEffect(GameObject enemy)
        {
            _effect.ApplyEffect(enemy);

            IDamageable damageable = enemy.GetComponent<IDamageable>();
            GameManager.Instance.StartCoroutine(DotDamage(damageable));
        }

        private IEnumerator DotDamage(IDamageable damageable)
        {
            float currentTime = 0;
            while (currentTime < _duration)
            {
                damageable.TakeDamage(_damage);
                Debug.Log($"도트 데미지 {_damage} 피해");
                currentTime += 1.0f;
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}

