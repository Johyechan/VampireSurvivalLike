using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : Movement
    {
        public override void Move(float speed)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 moveVec = new Vector2(x, y).normalized;

            _rigid2D.velocity = moveVec * speed;
        }
    }
}

