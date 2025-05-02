using Enemy.Boss.Interface;
using Enemy.Boss.State;
using Enemy.Boss.State.Part;
using Enemy.Boss.Transition;
using Enemy.Transition;
using MyUtil;
using MyUtil.FSM;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public class BossPartBase : BossHealth, IBossPart
    {
        [SerializeField] protected BossPatternSO _so;
        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _hitState;
        protected IState _destroyedState;

        protected BossAttackHandler _attackHandler;

        private SpriteRenderer _spriteRenderer;

        private TransitionHandler _transitionHandler;

        private List<ITransition> _transitions = new();

        public IBossPattern Pattern { get; protected set; }

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _machine = new StateMachine();

            _idleState = new BossPartIdleState();
            _hitState = new BossHitState(this, _spriteRenderer, 0.25f);
            _destroyedState = new BossPartDestroyedState();

            _transitions = new List<ITransition>
            {
                new BossPartDestroyedTransition(this, _machine, _destroyedState),
                new BossHitTransition(this, _machine, _hitState),
                new BossPartIdleTransition(this, _machine, _idleState)
            };

            _transitionHandler = new TransitionHandler(_transitions);
        }

        protected virtual void Update()
        {
            if (_transitionHandler.HandleTransitions()) return;

            _machine.UpdateExecute();
        }

        public void Init(BossAttackHandler attackHandler)
        {
            _attackHandler = attackHandler;
        }
    }
}

