using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace FSM
{
    public class EnemyAttackState : IState
    {
        private EnemyMovement _movement;

        private float _power;

        public EnemyAttackState(EnemyMovement movement, float power)
        {
            _movement = movement;
            _power = power;
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

