using Enemy.Boss.State;
using Enemy.Boss.Transition;
using Enemy.Interface.Strategy;
using Enemy.Strategy.Move;
using Manager;
using MyUtil;
using MyUtil.FSM;
using MyUtil.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot
{
    public class RobotBossController : PartedBossBaseController
    {
        private IState _moveState;

        private IEnemyMoveStrategy _moveStrategy;

        private TransitionHandler _transitionHandler;

        private ITransition _deathTransition;
        private ITransition _attackTransition;
        private ITransition _moveAndIdleTransition;

        protected override void Awake()
        {
            base.Awake();

            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.speed, "Player");

            //_moveState = new BossMoveState(_moveStrategy);

            //_deathTransition = new BossDeathTransition();
            //_attackTransition = new BossAttackTransition();
            //_moveAndIdleTransition = new BossMoveAndIdleTransition();

            _transitions = new List<ITransition>
            {
                _deathTransition,
                _attackTransition,
                _moveAndIdleTransition
            };

            _transitionHandler = new TransitionHandler(_transitions);
        }

        protected override void StateTransition()
        {
            foreach(var transition in _transitions)
            {
                if (transition.TryTransitionToThisState()) return;
            }
        }
    }
}

