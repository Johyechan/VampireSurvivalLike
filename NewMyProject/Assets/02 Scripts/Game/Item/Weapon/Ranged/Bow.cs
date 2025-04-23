using Enemy;
using Item.Effect;
using Item.Effect.OneItem;
using Item.Strategy;
using Manager;
using MyUtil;
using System.Collections;
using UnityEngine;

namespace Item.Weapon.Ranged
{
    public class Bow : RangedWeapon
    {
        private float _resetTime = 3f;
        private float _currentTime = 0;

        private bool _increase = false;

        private AttackSpeedIncreaseEffect _attackSpeedEffect;

        protected override void Awake()
        {
            base.Awake();

            _attackSpeedEffect = new AttackSpeedIncreaseEffect();
            EffectContainer.AddEffect(_attackSpeedEffect);
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
                GameObject enemy = AreaUtil.CheckCloseTargetInArea(transform, itemSO.range, LayerMask.GetMask("Enemy"));
                if (enemy != null)
                {
                    EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();
                    if (!_increase)
                    {
                        _increase = true;
                        _currentTime = 0;
                    }
                    
                    _weaponStrategy.Attack(enemy);
                    EffectContainer.Effect(enemyBase);
                    yield return new WaitForSeconds(StatManager.Instance.ReturnAttackSpeedPerSecond(_attackSpeedEffect.ReturnAttackSpeed()));
                }
                else
                {
                    if(_increase)
                    {
                        _currentTime += Time.deltaTime;
                        if (_currentTime > _resetTime)
                        {
                            _attackSpeedEffect.ResetAttackSpeed();
                            _increase = false;
                        }
                    }
                }

                yield return null;
            }
        }
    }
}