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

        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _moveState;
        protected IState _attackState;
        protected IState _hitState;
        protected IState _deathState;

        protected virtual void Awake()
        {
            _movement = GetComponent<EnemyMovement>();

            _machine = new StateMachine();

            _idleState = new EnemyIdleState();
            _moveState = new EnemyMoveState(_movement, transform, GameManager.Instance.player.transform.position, _so.speed);
            _attackState = new EnemyAttackState();
            _hitState = new EnemyHitState();
            _deathState = new EnemyDeathState();
        }

        void Update()
        {
            _machine.UpdateExecute();

            if (_movement.CheckArea(_so.playerCheckRange) && !_machine.IsCurrentState(_moveState))
            {
                _machine.ChangeState(_moveState);
            }
        }
    }
}

