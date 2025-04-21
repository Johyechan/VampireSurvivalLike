using Item.Effect;
using Item.Interface;
using Item.Strategy;
using Manager;
using MyUtil.Interface;
using Player.Enum;
using System.Collections;
using UnityEngine;

namespace Item.Weapon
{
    public class Sword : WeaponItem
    {
        private float _damage;

        private IDamageable _damageable;

        private void Awake()
        {
            _weaponStrategy = new MeleeWeaponStrategy(transform, itemSO.range, "Enemy", this);

            _damage = StatManager.Instance.AllStat.attackDamage + StatManager.Instance.PlayerStat.damage;

            EffectContainer = new ItemEffectContainer();
        }

        private void OnEnable()
        {
            StartCoroutine(AttackCo());
        }

        private void OnDisable()
        {
            StopCoroutine(AttackCo());
        }

        protected void OnDamage()
        {
            switch(itemSO.role)
            {
                case RoleType.Reaper:
                    _damage = StatManager.Instance.AllStat.soulPower + StatManager.Instance.PlayerStat.damage;
                    break;
                case RoleType.Magician:
                    _damage = StatManager.Instance.AllStat.abilityPower + StatManager.Instance.PlayerStat.damage;
                    break;
                default:
                    _damage = StatManager.Instance.AllStat.attackDamage + StatManager.Instance.PlayerStat.damage;
                    break;
            }

            _damageable.TakeDamage(_damage);
        }

        private IEnumerator AttackCo()
        {
            while(!GameManager.Instance.gameOver)
            {
                GameObject enemy = _weaponStrategy.CheckArea();
                if (enemy != null)
                {
                    IsAttackEnd = false;
                    _damageable = enemy.GetComponent<IDamageable>();
                    _weaponStrategy.Attack();
                    EffectContainer.Effect();
                    yield return new WaitUntil(() => IsAttackEnd);
                    yield return new WaitForSeconds(StatManager.Instance.ReturnAttackSpeedPerSecond());
                }

                yield return null;
            }
        }
    }
}

