using Enemy.State;
using Enemy.Transition.Normal;
using MyUtil;
using MyUtil.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Normal
{
    // 일반 적의 공통 로직을 처리하는 기반 클래스
    public class NormalEnemyBase : EnemyBase
    {
        // 애니메이션 해시값
        protected int _moveHash = Animator.StringToHash("Move");
        protected int _attackHash = Animator.StringToHash("Attack");
        protected int _hitHash = Animator.StringToHash("Hit");
        protected int _deathHash = Animator.StringToHash("Death");
        protected int _idleHash = Animator.StringToHash("Idle");

        // 상태 전환을 처리하는 변수들
        private ITransition _deathTransition;
        private ITransition _hitTransition;
        private ITransition _knockbackTransition;
        private ITransition _attackTransition;
        private ITransition _moveAndIdleTransition;

        // 상태 전환을 처리하는 변수들을 처리 순서대로 저장할 리스트
        private List<ITransition> _transitions;

        // 상태 전환을 관리하는 클래스
        private TransitionHandler _transitionHandler;

        // 상태 초기화
        protected void Init()
        {
            _idleState = new EnemyIdleState(_animator, _idleHash);
            _moveState = new EnemyMoveState(_animator, _moveHash, _moveStrategy);
            _attackState = new EnemyAttackState(_animator, _attackHash, _attackStrategy);
            _hitState = new EnemyHitState(_animator, _hitHash);
            _deathState = new EnemyDeathState(_animator, _deathHash);

            _deathTransition = new NormalDeathStateTransition(_machine, _health, _deathState);
            _hitTransition = new NormalHitStateTransition(_machine, _health, _hitState);
            _knockbackTransition = new NormalKnockbackTransition(this);
            _attackTransition = new NormalAttackStateTransition(_machine, _attackState, this, _attackStrategy);
            _moveAndIdleTransition = new NormalMoveAndIdleStateTransition(_machine, _moveStrategy, _moveState, _idleState);

            _transitions = new List<ITransition>
            {
                _deathTransition,
                _hitTransition,
                _knockbackTransition,
                _attackTransition,
                _moveAndIdleTransition,
            };

            _transitionHandler = new TransitionHandler(_transitions);
        }

        // 적의 상태를 상황에 따라 전환
        protected override void StateTransition()
        {
            if (_transitionHandler.HandleTransitions()) return;
        }
    }
}