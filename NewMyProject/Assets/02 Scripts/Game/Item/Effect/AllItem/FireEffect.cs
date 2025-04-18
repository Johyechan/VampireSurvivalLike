using Enemy;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Item.Effect.AllItem
{
    // 적을 불태우는 도트 데미지 효과
    public class FireEffect : IItemEffect
    {
        private IItemEffect _effect;

        private float _dotDamage;

        public FireEffect(IItemEffect effect, float dotDamage)
        {
            _effect = effect;
            _dotDamage = dotDamage;
        }

        public void Effect(EnemyBase enemy = null)
        {
            if(enemy != null)
            {
                enemy.StartCoroutine(DotDamage(enemy));
            }
        }

        private IEnumerator DotDamage(EnemyBase enemy)
        {
            IDamageable damageable = enemy.gameObject.GetComponent<IDamageable>();
            for(int i = 0; i < 5; i++)
            {
                damageable.TakeDamage(_dotDamage);
                yield return new WaitForSeconds(1);
            }
        }

        public void RemoveEffect()
        {
            
        }
    }
}

