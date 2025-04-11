using Item.Strategy;
using Manager;
using System.Collections;
using UnityEngine;

namespace Item.Weapon
{
    public class Bow : WeaponItem
    {
        private Vector3 _originScale;

        private Quaternion _originRotation;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _itemSO.range);
        }

        private void Awake()
        {
            _originScale = transform.localScale;
            _originRotation = transform.rotation;

            _weaponStrategy = new RangedWeaponStrategy(transform, _itemSO.range, "Enemy", StatManager.Instance.AllStat.attackDamage + StatManager.Instance.PlayerStat.damage, _itemSO.fireSpeed, _itemSO.projectileType);
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
            while(true)
            {
                if(_weaponStrategy.CheckArea() != null)
                {
                    _weaponStrategy.Attack();
                    yield return new WaitForSeconds(1);
                }

                yield return null;
            }
        }
    }
}