using Enemy.Boss.Interface;
using Enemy.Interface.Strategy;
using MyUtil;
using MyUtil.FSM;
using MyUtil.Interface;
using MyUtil.Pool;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _so.playerCheckRange);
        }

        protected virtual void Awake()
        {
            _machine = new StateMachine();

            _animationHandler = new BossAnimationHandler();
            _animationHandler.BossAnimator = GetComponent<Animator>();

            _attackHandler = new BossAttackHandler(_so.attackDelay);
        }

        protected virtual void Start()
        {
            StartCoroutine(_attackHandler.AttackDelayCo());
        }

        protected virtual void Update()
        {
            StateTransition();

            _machine.UpdateExecute();
        }

        private void OnDead()
        {
            StopAllCoroutines();
            Debug.Log("»ç¸Á");
        }

        private void StateTransition()
        {
            if (_transitionHandler.HandleTransitions()) return;
        }
    }
}

