using Item.Interface;
using Item.Strategy;
using Manager;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Item.Weapon
{
    public class Sword : WeaponItem
    {
        private Animator _animator;

        private int _attackHash = Animator.StringToHash("Attack");

        private float _damage;

        private IDamageable _damageable;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, itemSO.range);
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _weaponStrategy = new MeleeWeaponStrategy(transform, itemSO.range, "Enemy", _animator, _attackHash);

            _damage = StatManager.Instance.AllStat.attackDamage + StatManager.Instance.PlayerStat.damage;
        }

        private void OnEnable()
        {
            StartCoroutine(AttackCo());
        }

        private void OnDisable()
        {
            StopCoroutine(AttackCo());
        }

        protected void AttackEnd()
        {
            _animator.SetBool(_attackHash, false);
        }

        protected void OnDamage()
        {
            _damageable.TakeDamage(_damage);
        }

        private IEnumerator AttackCo()
        {
            while(!GameManager.Instance.gameOver)
            {
                GameObject enemy = _weaponStrategy.CheckArea();
                if (enemy != null)
                {
                    _damageable = enemy.GetComponent<IDamageable>();
                    _weaponStrategy.Attack();
                    yield return new WaitForSeconds(StatManager.Instance.ReturnAttackSpeedPerSecond());
                }

                yield return null;
            }
        }
    }
}

