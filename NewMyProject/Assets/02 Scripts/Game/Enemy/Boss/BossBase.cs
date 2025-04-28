using Enemy.Boss.Interface;
using Enemy.Interface.Strategy;
using MyUtil;
using MyUtil.FSM;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss
{
    public class BossBase : MonoBehaviour
    {
        [SerializeField] protected BossBaseSO _so;

        protected List<ITransition> _transitions = new();

        protected BossAnimationHandler _animationHandler;
        protected BossAttackHandler _attackHandler;

        protected TransitionHandler _transitionHandler;

        protected IBossAttackStrategy _attackStrategy;

        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _attackState;
        protected IState _deadState;

        public bool IsDead { get; set; }

        protected virtual void Awake()
        {
            _machine = new StateMachine();

            _animationHandler = new BossAnimationHandler();
            _animationHandler.BossAnimator = GetComponent<Animator>();

            _attackHandler = new BossAttackHandler(_so.attackDelay);
        }
    }
}

