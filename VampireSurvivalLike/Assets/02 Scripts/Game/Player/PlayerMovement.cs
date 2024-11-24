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

        public bool MoveKeyDown()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                return true;
            }

            return false;
        }

        public bool MoveKeyUp()
        {
            if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
            {
                return true;
            }

            return false;
        }
    }
}

