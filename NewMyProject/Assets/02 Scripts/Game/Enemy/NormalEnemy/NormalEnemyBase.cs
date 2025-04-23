using Enemy.State;
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

        private List<Func<bool>> _transitions;

        protected override void Awake()
        {
            base.Awake();

            _transitions = new List<Func<bool>>
            {
                TryTransitionToDeath,
                TryTransitionToHit,
                () => _isknockback,
                TryTransitionToAttack,
                TryTransitionToMoveAndIdle
            };
        }

        // 상태 초기화
        protected void Init()
        {
            _idleState = new EnemyIdleState(_animator, _idleHash);
            _moveState = new EnemyMoveState(_animator, _moveHash, _moveStrategy);
            _attackState = new EnemyAttackState(_animator, _attackHash, _attackStrategy);
            _hitState = new EnemyHitState(_animator, _hitHash);
            _deathState = new EnemyDeathState(_animator, _deathHash);
        }

        // 죽음 상태로 전환 시도
        private bool TryTransitionToDeath()
        {
            if (_health.IsDie)
            {
                if (!_machine.IsCurrentState(_deathState))
                {
                    _machine.ChangeState(_deathState);
                    return true;
                }
            }
            return false;
        }

        // 피격 상태로 전환 시도
        private bool TryTransitionToHit()
        {
            if (_health.IsHit)
            {
                _machine.ChangeState(_hitState);
                _health.IsHit = false;
                return true;
            }

            return false;
        }

        // 공격 상태로 전환 시도
        private bool TryTransitionToAttack()
        {
            if (_attackStrategy.CheckArea())
            {
                if (!_isAttackDelay)
                {
                    _isAttackDelay = true;
                    _machine.ChangeState(_attackState);
                    return true;
                }
            }

            return false;
        }

        // 이동 상태 또는 대기 상태로 전환 시도
        private bool TryTransitionToMoveAndIdle()
        {
            if (_moveStrategy.CheckArea())
            {
                if (!_machine.IsCurrentState(_moveState))
                {
                    _machine.ChangeState(_moveState);
                    return true;
                }
            }
            else
            {
                _machine.ChangeState(_idleState);
                return true;
            }

            return false;
        }

        // 적의 상태를 상황에 따라 전환
        protected override void StateTransition()
        {
            foreach(var transition in _transitions)
            {
                if (transition()) break;
            }
        }
    }
}