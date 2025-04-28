using Enemy.Boss.Interface;
using Enemy.Boss.State;
using MyUtil;
using MyUtil.FSM;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public abstract class PartedBossBaseController : MonoBehaviour
    {
        [SerializeField] protected PartedBossSO _so;

        [SerializeField] protected List<IBossPart> _parts = new();

        protected List<ITransition> _transitions;

        protected BossAnimationHandler _animationHandler;

        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _attackState;
        protected IState _deathState;

        private int _deathCount;

        public bool IsDeath { get; set; }

        protected virtual void Awake()
        {
            _deathCount = 0;
            IsDeath = false;

            _animationHandler = GetComponent<BossAnimationHandler>();

            _machine = new StateMachine();

            //_idleState = new BossIdleState();
            //_attackState = new BossAttackState();
            //_deathState = new BossDeathState();
        }

        protected virtual void Update()
        {
            if (IsDeath)
                return;

            foreach (var part in _parts)
            {
                BossHealth health = part as BossHealth;
                if(health.IsDestroy)
                {
                    _deathCount++;
                }
            }

            if(_deathCount >= _parts.Count)
            {
                IsDeath = true;
            }
            else
            {
                IsDeath = false;
            }

            StateTransition();
        }

        protected abstract void StateTransition();
    }
}

