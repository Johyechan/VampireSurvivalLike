using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayerDieState : IState
    {
        public void Enter()
        {
            Debug.Log("Player Die");
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

