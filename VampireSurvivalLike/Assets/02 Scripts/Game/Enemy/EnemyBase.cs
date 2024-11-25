using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Manager;
using UnityEditor;
using Pool;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        public EnemySO so;

        [SerializeField] protected ObjectPoolType _type;

        protected GameObject _player;

        protected Rigidbody2D _rigid2D;

        protected EnemyMovement _movement;

        protected EnemyHealth _health;

        protected IState _idleState;
        protected IState _attackState;
        protected IState _chaseState;
        protected IState _dieState;

        protected StateMachine _stateMachine;

        protected bool _isDead;
        protected bool _isOut;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, so.radius);
        }

        protected virtual void OnEnable()
        {
            _isDead = false;

            _player = GameManager.Instance.player;

            _movement = GetComponent<EnemyMovement>();

            _health = GetComponent<EnemyHealth>();

            _idleState = new EnemyIdleState(_movement);
            _chaseState = new EnemyChaseState(_movement, so.speed);
            _attackState = new EnemyAttackState(_movement, so.power);
            _dieState = new EnemyDieState(_movement, _type, gameObject);

            _stateMachine = new StateMachine();
        }

        protected virtual void Update()
        {
            if(_isOut)
            {
                _stateMachine.ChangeState(_idleState);
                return;
            }

            if (_health.IsDie && _isDead)
                return;

            if (_health.IsDie && !_isDead)
            {
                _stateMachine.ChangeState(_dieState);
                _isDead = true;
            }

            _stateMachine.UpdateExecute();
        }

        protected void OutCheck(float distance)
        {
            if (Vector2.Distance(_player.transform.position, transform.position) > distance)
            {
                ObjectPoolManager.Instance.ReturnObject(_type, gameObject);
            }
        }

        protected void CheckAttackArea(float radius)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0, LayerMask.GetMask("Player"));

            if (hit.collider)
            {
                _stateMachine.ChangeStateWithCoolTime(_attackState, so.attackCoolTime);

                //임시 이건 나중에 공격 상태일 때 적용하는 걸로 바꿔보자
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if(damageable != null)
                {
                    damageable.TakeDamage(so.power);
                }
            }
        }
    }
}

