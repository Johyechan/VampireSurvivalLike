using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class EnemyChaseState : IState
    {
        private EnemyMovement _movement;

        private float _speed;

        public EnemyChaseState(EnemyMovement movement, float speed)
        {
            _movement = movement;
            _speed = speed;
        }

        public void Enter()
        {
            Debug.Log("Enter Chase");
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

