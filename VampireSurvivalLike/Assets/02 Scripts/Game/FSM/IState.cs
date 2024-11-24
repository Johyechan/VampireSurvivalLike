using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public interface IState
    {
        void Enter();

        void Execute();

        void Exit();
    }
}

