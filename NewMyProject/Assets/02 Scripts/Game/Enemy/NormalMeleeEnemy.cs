using Enemy.State;
using Enemy.Strategy.Attack;
using Enemy.Strategy.Move;
using Manager;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy
{
    public class NormalMeleeEnemy : EnemyBase
    {
        private int _moveHash = Animator.StringToHash("Move");
        private int _attackHash = Animator.StringToHash("Attack");
        private int _hitHash = Animator.StringToHash("Hit");
        private int _deathHash = Animator.StringToHash("Death");

        protected override void Awake()
        {
            base.Awake();

            _moveStrategy = new EnemyPlayerFollowMove();
            _attackStrategy = new EnemyMeleeAttack(_so.damage);

            _idleState = new EnemyIdleState();
            _moveState = new EnemyMoveState(_animator, _moveHash, _moveStrategy, transform, GameManager.Instance.player.transform.position, _so.speed);
            _attackState = new EnemyAttackState(_animator, _attackHash, _attackStrategy);
            _hitState = new EnemyHitState(_animator, _hitHash, transform, _knockbackTime, _knockbackPower);
            _deathState = new EnemyDeathState(_animator, _deathHash);
        }
    }
}

