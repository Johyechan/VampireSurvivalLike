using Enemy;
using Enemy.State;
using Enemy.Strategy.Attack;
using Enemy.Strategy.Move;
using Manager;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Normal
{
    public class NormalRangedEnemy : EnemyBase
    {
        [SerializeField] private ObjectPoolType _fireType;
        [SerializeField] private float _fireSpeed;

        private int _moveHash = Animator.StringToHash("Move");
        private int _attackHash = Animator.StringToHash("Attack");
        private int _hitHash = Animator.StringToHash("Hit");
        private int _deathHash = Animator.StringToHash("Death");
        private int _idleHash = Animator.StringToHash("Idle");

        protected override void Awake()
        {
            _attackStrategy = new EnemyRangedAttack(transform, _so.attackRange, _so.damage, "Player", _fireType, _fireSpeed);
            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.speed, "Player");

            _idleState = new EnemyIdleState(_animator, _idleHash);
            _moveState = new EnemyMoveState(_animator, _moveHash, _moveStrategy);
            _attackState = new EnemyAttackState(_animator, _attackHash, _attackStrategy);
            _hitState = new EnemyHitState(_animator, _hitHash);
            _deathState = new EnemyDeathState(_animator, _deathHash);
        }

        protected override void StateTransition()
        {
            throw new System.NotImplementedException();
        }
    }
}

