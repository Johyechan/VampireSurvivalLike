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

        public IState buyState;

        public IState salesState;

        public Vector3 originPosition;

        public Quaternion originRotaiton;

        public ItemShape shape;

        public Transform parent;
    }
}

