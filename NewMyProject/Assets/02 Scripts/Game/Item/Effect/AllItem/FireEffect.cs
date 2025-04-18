using Enemy;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Item.Effect.AllItem
{
    // ���� ���¿�� ��Ʈ ������ ȿ��
    public class FireEffect : IItemEffect
    {
        private float _dotDamage;

        public FireEffect(float dotDamage)
        {
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
    }
}

