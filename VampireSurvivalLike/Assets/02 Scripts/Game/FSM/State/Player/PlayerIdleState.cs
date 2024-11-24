using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayerIdleState : IState
    {
        private PlayerMovement _movement;

        public PlayerIdleState(PlayerMovement movement)
        {
            _movement = movement;
        }

        public void Enter()
        {
            _movement.StopImmediately();
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

