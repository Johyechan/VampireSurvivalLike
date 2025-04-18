using Item.Effect;
using Item.Effect.OneItem;
using Item.Strategy;
using Manager;
using System.Collections;
using UnityEngine;

namespace Item.Weapon
{
    public class Bow : WeaponItem
    {
        private float _resetTime = 3f;
        private float _currentTime = 0;

        private bool _increase = false;

        private AttackSpeedIncreaseEffect _attackSpeedEffect;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, itemSO.range);
        }

        private void Awake()
        {
            _weaponStrategy = new RangedWeaponStrategy(transform, itemSO.range, "Enemy", StatManager.Instance.AllStat.attackDamage + StatManager.Instance.PlayerStat.damage, itemSO.fireSpeed, itemSO.projectileType);

            _effect = new NonEffect();
            _effect = new AttackSpeedIncreaseEffect(_effect);
            _attackSpeedEffect = _effect as AttackSpeedIncreaseEffect;
        }

        private void OnEnable()
        {
            StartCoroutine(Fire());
        }

        private void OnDisable()
        {
            StopCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            while(!GameManager.Instance.gameOver)
            {
                if(_weaponStrategy.CheckArea() != null)
                {
                    if(!_increase)
                    {
                        _increase = true;
                        _currentTime = 0;
                    }
                    
                    _weaponStrategy.Attack();
                    _effect.Effect();
                    yield return new WaitForSeconds(StatManager.Instance.ReturnAttackSpeedPerSecond(_attackSpeedEffect.ReturnAttackSpeed()));
                }
                else
                {
                    if(_increase)
                    {
                        _currentTime += Time.deltaTime;
                        if (_currentTime > _resetTime)
                        {
                            _effect.RemoveEffect();
                            _increase = false;
                        }
                    }
                }

                yield return null;
            }
        }
    }
}