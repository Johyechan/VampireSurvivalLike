using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _movement;

        void Start()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        
        void FixedUpdate()
        {
            _movement.Move(10);
        }
    }
}

