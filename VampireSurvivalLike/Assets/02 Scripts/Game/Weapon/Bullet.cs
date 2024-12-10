using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Bullet : Hitter
    {
        protected override void OnEnable()
        {
            base.OnEnable();
        }

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

