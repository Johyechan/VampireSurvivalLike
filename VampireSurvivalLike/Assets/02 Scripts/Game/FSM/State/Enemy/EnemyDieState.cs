using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class EnemyDieState : IState
    {
        public void Enter()
        {
            Debug.Log("Enemy Die");
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

