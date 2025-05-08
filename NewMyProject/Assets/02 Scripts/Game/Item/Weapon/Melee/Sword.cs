using Enemy;
using Item.Effect;
using Item.Interface;
using Item.Strategy;
using Manager;
using MyUtil;
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
            while(!GameManager.Instance.GameOver)
            {
                GameObject enemy = AreaUtil.CheckCloseTargetInArea(transform, itemSO.range, LayerMask.GetMask("Enemy"));
                if (enemy != null)
                {
                    EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();
                    IsAttackEnd = false;
                    _damageable = enemy.GetComponent<IDamageable>();
                    _weaponStrategy.Attack(enemy);
                    EffectContainer.Effect(enemyBase);
                    yield return new WaitUntil(() => IsAttackEnd);
                    yield return new WaitForSeconds(StatManager.Instance.ReturnAttackSpeedPerSecond());
                }

                yield return null;
            }
        }
    }
}

