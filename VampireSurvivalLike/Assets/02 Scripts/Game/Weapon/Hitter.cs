using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Hitter : MonoBehaviour
    {
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

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();

                damageable.TakeDamage(_damage);
            }
        }
    }
}

