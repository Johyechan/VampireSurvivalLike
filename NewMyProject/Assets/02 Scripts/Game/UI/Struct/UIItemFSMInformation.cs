using MyUtil.FSM;
using UnityEngine;

namespace MyUI.Struct
{
    public struct UIItemFSMInformation
    {
        public IState idleState;

        public IState draggingState;

        public IState placementCheckState;

        public IState placementFailedState;

        public IState placementSuccessState;

        public Vector3 originPos;
    }
}

