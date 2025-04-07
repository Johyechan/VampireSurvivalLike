using Enemy.State;
using Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected EnemySO _so;

        protected EnemyMovement _movement;

        protected EnemyHealth _health;

        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _moveState;
        protected IState _attackState;
        protected IState _hitState;
        protected IState _deathState;

        private float _knockbackTime = 0.3f;
        private float _knockbackPower = 1f;

        public bool IsDie { get { return _isDie; } }
        private bool _isDie = false;

        protected virtual void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _health = GetComponent<EnemyHealth>();

            _machine = new StateMachine();

            _idleState = new EnemyIdleState();
            _moveState = new EnemyMoveState(_movement, transform, GameManager.Instance.player.transform.position, _so.speed);
            _attackState = new EnemyAttackState();
            _hitState = new EnemyHitState(transform, _knockbackTime, _knockbackPower);
            _deathState = new EnemyDeathState();
        }

        protected virtual void OnEnable()
        {
            _isDie = false;
            _machine.ChangeState(_idleState);
        }

        void Update()
        {
            _machine.UpdateExecute();

            if (_movement.CheckArea(_so.playerCheckRange) && !_machine.IsCurrentState(_moveState))
            {
                _machine.ChangeState(_moveState);
            }
        }

        public void Hit()
        {
            _machine.ChangeState(_hitState);
            _machine.DelayChangeState(_idleState, _knockbackTime);
        }

        public void Death()
        {
            _isDie = true;
            _machine.ChangeState(_deathState);
        }
    }
}

