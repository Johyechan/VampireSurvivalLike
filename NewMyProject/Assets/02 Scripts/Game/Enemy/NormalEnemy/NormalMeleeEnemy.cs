using Enemy.State;
using Enemy.Strategy.Attack;
using Enemy.Strategy.Move;
using Manager;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Normal
{
    public class NormalMeleeEnemy : EnemyBase
    {
        private int _moveHash = Animator.StringToHash("Move");
        private int _attackHash = Animator.StringToHash("Attack");
        private int _hitHash = Animator.StringToHash("Hit");
        private int _deathHash = Animator.StringToHash("Death");
        private int _idleHash = Animator.StringToHash("Idle");

        protected override void Awake()
        {
            base.Awake();

            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.speed, "Player");
            _attackStrategy = new EnemyMeleeAttack(transform, _so.attackRange, _so.damage, "Player");

            _idleState = new EnemyIdleState(_animator, _idleHash);
            _moveState = new EnemyMoveState(_animator, _moveHash, _moveStrategy);
            _attackState = new EnemyAttackState(_animator, _attackHash, _attackStrategy);
            _hitState = new EnemyHitState(_animator, _hitHash);
            _deathState = new EnemyDeathState(_animator, _deathHash);
        }

        protected override void StateTransition()
        {
            if(_health.IsDie)
            {
                if(!_machine.IsCurrentState(_deathState))
                {
                    _machine.ChangeState(_deathState);
                }
                return;
            }

            if(_health.IsHit)
            {
                _machine.ChangeState(_hitState);
                _health.IsHit = false;
                return;
            }

            if (_isknockback)
                return;

            if (_attackStrategy.CheckArea())
            {
                if (!_isAttackDelay)
                {
                    _isAttackDelay = true;
                    _machine.ChangeState(_attackState);
                }
                return;
            }

            if(_moveStrategy.CheckArea())
            {
                if (!_machine.IsCurrentState(_moveState))
                {
                    _machine.ChangeState(_moveState);
                }
                return;
            }
            else
            {
                _machine.ChangeState(_idleState);
                return;
            }
        }
    }
}

