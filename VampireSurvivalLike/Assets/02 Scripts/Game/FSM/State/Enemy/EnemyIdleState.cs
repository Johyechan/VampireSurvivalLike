using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class EnemyIdleState : IState
    {
        private EnemyMovement _movement;

        public EnemyIdleState(EnemyMovement movement)
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

