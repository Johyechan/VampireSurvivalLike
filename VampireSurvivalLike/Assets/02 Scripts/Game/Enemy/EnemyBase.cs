using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Manager;
using UnityEditor;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        public EnemySO so;

        protected Rigidbody2D _rigid2D;

        protected EnemyMovement _movement;

        protected EnemyHealth _health;

        protected IState _idleState;
        protected IState _attackState;
        protected IState _chaseState;
        protected IState _dieState;

        protected StateMachine _stateMachine;

        protected bool _isDead;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, so.radius);
        }

        protected virtual void Start()
        {
            _isDead = false;

            _movement = GetComponent<EnemyMovement>();

            _health = GetComponent<EnemyHealth>();

            _idleState = new EnemyIdleState(_movement);
            _chaseState = new EnemyChaseState(_movement, so.speed);
            _attackState = new EnemyAttackState(_movement, so.power);
            _dieState = new EnemyDieState();

            _stateMachine = new StateMachine();

            _stateMachine.ChangeState(_idleState);
        }

        protected virtual void Update()
        {
            if (_health.IsDie && _isDead)
                return;

            if (_health.IsDie && !_isDead)
            {
                _stateMachine.ChangeState(_dieState);
                _isDead = true;
            }

            _stateMachine.UpdateExecute();
        }

        protected void CheckAttackArea(float radius)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0, LayerMask.GetMask("Player"));

            if (hit.collider)
            {
                _stateMachine.ChangeStateWithCoolTime(_attackState, so.attackCoolTime);

                //�ӽ� �̰� ���߿� ���� ������ �� �����ϴ� �ɷ� �ٲ㺸��
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if(damageable != null)
                {
                    damageable.TakeDamage(so.power);
                }
            }
        }
    }
}

