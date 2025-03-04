using Manager;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayerDieState : IState
    {
        private PlayerMovement _movement;

        public PlayerDieState(PlayerMovement movement)
        {
            _movement = movement;
        }

        public void Enter()
        {
            Debug.Log("Player Die");
            GameManager.Instance.playerDead = true;
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

