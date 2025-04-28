using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public abstract class BossStateBase : IState
    {
        protected Animator _animator;

        protected int _hash;

        public BossStateBase(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        public abstract void Enter();

        public abstract void Execute();

        public abstract void Exit();
    }
}

