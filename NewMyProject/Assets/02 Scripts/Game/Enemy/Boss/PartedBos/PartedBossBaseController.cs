using Enemy.Boss.Interface;
using Enemy.Boss.State;
using Enemy.Boss.Strategy;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public abstract class PartedBossBaseController : BossBase
    {
        [SerializeField] protected List<IBossPart> _parts = new();

        private int _deathCount;

        protected override void Awake()
        {
            base.Awake();

            _deathCount = 0;
            IsDead = false;

            _attackStrategy = new PartedBossAttackStrategy(_parts);

            _idleState = new BossIdleState(_animationHandler.BossAnimator, _animationHandler.IdleHash);
            _attackState = new BossAttackState(_animationHandler.BossAnimator, _animationHandler.AttackHash, _attackStrategy);
            _deadState = new BossDeathState(_animationHandler.BossAnimator, _animationHandler.DeadHash);
        }

        protected virtual void Update()
        {
            if (IsDead)
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
                IsDead = true;
            }
            else
            {
                IsDead = false;
            }

            StateTransition();
        }

        protected abstract void StateTransition();
    }
}

