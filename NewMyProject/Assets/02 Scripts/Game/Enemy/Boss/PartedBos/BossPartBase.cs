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
        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _hitState;
        protected IState _destroyedState;

        protected BossAttackHandler _attackHandler;

        private SpriteRenderer _spriteRenderer;

        private TransitionHandler _transitionHandler;

        private List<ITransition> _transitions = new();

        public IBossPattern Pattern { get; protected set; }

        public float Damage { get; private set; }

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _machine = new StateMachine();

            _idleState = new BossPartIdleState();
            _hitState = new BossHitState(this, _spriteRenderer, 0.25f);
            _destroyedState = new BossPartDestroyedState(this);

            _transitions = new List<ITransition>
            {
                new BossPartDestroyedTransition(this, _machine, _destroyedState),
                new BossHitTransition(this, _machine, _hitState),
                new BossPartIdleTransition(this, _machine, _idleState)
            };

            _transitionHandler = new TransitionHandler(_transitions);
        }

        public void PatternEnd()
        {
            Pattern.PatternEnd();
        }

        protected virtual void Update()
        {
            if (_transitionHandler.HandleTransitions()) return;

            _machine.UpdateExecute();
        }

        public void Init(BossAttackHandler attackHandler, float damage)
        {
            _attackHandler = attackHandler;
            Damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();
                damageable.TakeDamage(Damage);
            }
        }
    }
}

