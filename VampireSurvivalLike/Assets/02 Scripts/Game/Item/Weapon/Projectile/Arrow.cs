using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatItem
{
    public class Arrow : Projectile
    {
        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}

