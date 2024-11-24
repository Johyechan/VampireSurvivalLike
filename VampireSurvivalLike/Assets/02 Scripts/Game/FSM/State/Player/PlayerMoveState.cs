using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayerMoveState : IState
    {
        private PlayerMovement _movement;

        private float _speed;

        public PlayerMoveState(PlayerMovement movement, float speed)
        {
            _movement = movement;
            _speed = speed;
        }

        public void Enter()
        {
            
        }

        public void Execute()
        {
            _movement.Move(_speed);
        }

        public void Exit()
        {
            
        }
    }
}

