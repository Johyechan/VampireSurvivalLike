using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Hitter : WeaponBase
    {
        [SerializeField] private bool _isCanDestroy;

        private float _damage;

        public float Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }

        private float _lifeTime;

        public float LifeTime
        {
            get
            {
                return _lifeTime;
            }
            set
            {
                _lifeTime = value;
            }
        }

        protected virtual void OnEnable()
        {

        }

        protected virtual void OnDisable()
        {
            StopCoroutine(DeathCoolCo());
        }

        public void DeathCoolStart()
        {
            StartCoroutine(DeathCoolCo());
        }

        private IEnumerator DeathCoolCo()
        {
            yield return new WaitForSeconds(_lifeTime);
            ObjectPoolManager.Instance.ReturnObject(type, gameObject);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();

                damageable.TakeDamage(_damage);

                if(_isCanDestroy)
                {
                    ObjectPoolManager.Instance.ReturnObject(type, gameObject);
                }
            }
        }
    }
}

