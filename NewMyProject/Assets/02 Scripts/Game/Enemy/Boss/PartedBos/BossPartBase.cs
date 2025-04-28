using Enemy.Boss.Interface;
using MyUtil.FSM;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public class BossPartBase : BossHealth, IBossPart, IDamageable
    {
        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _hitState;
        protected IState _destroyState;

        public List<IBossPattern> Patterns { get; protected set; }

        protected virtual void Awake()
        {
            _machine = new StateMachine();
        }

        public void RandomPattern()
        {
            int randomIndex = Random.Range(0, Patterns.Count);
            Patterns[randomIndex].Pattern();
        }
    }
}

