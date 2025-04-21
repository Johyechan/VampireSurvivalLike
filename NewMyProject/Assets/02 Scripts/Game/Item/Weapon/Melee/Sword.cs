using Enemy;
using Item.Effect;
using Item.Interface;
using Item.Strategy;
using Manager;
using MyUtil.Interface;
using Player.Enum;
using System.Collections;
using UnityEngine;

namespace Item.Weapon.Melee
{
    public class Sword : MeleeWeapon
    {
        private void OnEnable()
        {
            StartCoroutine(AttackCo());
        }

        private void OnDisable()
        {
            StopCoroutine(AttackCo());
        }

        private IEnumerator AttackCo()
        {
            while(!GameManager.Instance.gameOver)
            {
                GameObject enemy = CheckArea(transform, itemSO.range, "Enemy");
                if (enemy != null)
                {
                    EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();
                    IsAttackEnd = false;
                    _damageable = enemy.GetComponent<IDamageable>();
                    _weaponStrategy.Attack();
                    EffectContainer.Effect(enemyBase);
                    yield return new WaitUntil(() => IsAttackEnd);
                    yield return new WaitForSeconds(StatManager.Instance.ReturnAttackSpeedPerSecond());
                }

                yield return null;
            }
        }
    }
}

