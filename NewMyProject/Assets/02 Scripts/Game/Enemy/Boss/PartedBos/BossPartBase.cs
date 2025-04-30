using Enemy.Boss.Interface;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public class BossPartBase : BossHealth, IBossPart
    {
        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _hitState;
        protected IState _destroyState;

        protected BossAttackHandler _attackHandler;

        public List<IBossPattern> Patterns { get; protected set; }

        protected virtual void Awake()
        {
            _machine = new StateMachine();
        }

        public void Init(BossAttackHandler attackHandler)
        {
            _attackHandler = attackHandler;
        }

        public void RandomPattern()
        {
            int randomIndex = Random.Range(0, Patterns.Count);
            Patterns[randomIndex].Pattern();
        }
    }
}

