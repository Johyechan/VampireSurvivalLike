using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : Movement
    {
        public override void Move(float speed)
        {
            Vector2 dir = (GameManager.Instance.player.transform.position - transform.position).normalized;

            _rigid2D.velocity = dir * speed;
        }
    }
}

