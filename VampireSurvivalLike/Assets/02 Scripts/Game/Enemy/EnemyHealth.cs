using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : Health
    {
        private EnemyBase _base;

        protected override void Start()
        {
            base.Start();

            _base = GetComponent<EnemyBase>();

            _isDie = false;

            _hp = _base.so.hp;
        }

        protected override void Death()
        {
            death?.Invoke();
        }

        protected override void Die()
        {
            _isDie = true;
        }
    }
}

