using Enemy.Boss.Interface;
using Enemy.Boss.State;
using Enemy.Boss.Strategy;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public class PartedBossBaseController : BossBase
    {
        [SerializeField] protected List<BossPartBase> _parts;

        private int _deathCount;

        protected override void Awake()
        {
            base.Awake();

            _deathCount = 0;
            IsDead = false;

            _attackStrategy = new PartedBossAttackStrategy(_parts);

            _idleState = new BossIdleState(_animationHandler.BossAnimator, _animationHandler.IdleHash);
            _attackState = new BossAttackState(_attackStrategy);
            _deadState = new BossDeathState(_animationHandler.BossAnimator, _animationHandler.DeadHash);

            foreach(var part in _parts)
            {
                part.MaxHp = _so.maxHP / _parts.Count;
                part.Init(_attackHandler);
            }
        }

        protected override void Update()
        {
            if (IsDead)
                return;

            foreach (var part in _parts)
            {
                BossHealth health = part;
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

            base.Update();
        }
    }
}

