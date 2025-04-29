using Enemy.Boss.State;
using Enemy.Boss.Transition;
using Enemy.Interface.Strategy;
using Enemy.Strategy.Move;
using Manager;
using MyUtil;
using MyUtil.FSM;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot
{
    public class RobotBossController : PartedBossBaseController
    {
        private IState _moveState;

        private IEnemyMoveStrategy _moveStrategy;

        private ITransition _deathTransition;
        private ITransition _attackTransition;
        private ITransition _moveAndIdleTransition;

        protected override void Awake()
        {
            base.Awake();

            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.moveSpeed, "Player");

            _moveState = new BossMoveState(_animationHandler.BossAnimator, _animationHandler.MoveHash, _moveStrategy);

            _deathTransition = new BossDeathTransition(this, _machine, _deadState);
            _attackTransition = new BossAttackTransition(_machine, _attackHandler, _attackState);
            _moveAndIdleTransition = new BossMoveAndIdleTransition(_machine, _moveState, _idleState, _moveStrategy);

            _transitions = new List<ITransition>
            {
                _deathTransition,
                _attackTransition,
                _moveAndIdleTransition
            };

            _transitionHandler = new TransitionHandler(_transitions);
        }
    }
}

