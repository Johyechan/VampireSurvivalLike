using Enemy.Interface;
using Enemy.Interface.Strategy;
using Enemy.State;
using Manager;
using MyUtil.FSM;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    // ���� �⺻������ ������ �� ��ɵ��� ���� Ŭ����
    public abstract class EnemyBase : EnemyBaseVariables
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _so.attackRange);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _so.playerCheckRange);
        }

        protected virtual void OnEnable()
        {
            // �ʱ�ȭ�� ���� �׻� ���Ӱ� �����Ǹ� �� ������Ʈ Ǯ���� ���Ӱ� �������� ��� ����ִ� ����
            _isDie = false;
            IsAttackDelay = false;
            Isknockback = false;
            // �׸��� �⺻ ���·� ���� ��ȯ
            _machine.ChangeState(_idleState);
        }

        void Update()
        {
            // Update���� �ݺ������� �� ������ Execute�� ����
            if(GameManager.Instance.gameOver)
            {
                return;
            }

            _machine.UpdateExecute();

            if (IsAttackDelay)
            {
                _attackHandler.AttackDelay();
            }

            StateTransition();
        }

        protected abstract void StateTransition();

        protected void AttackEnd()
        {
            _machine.ChangeState(_idleState);
            IsAttackDelay = true;
        }

        // ����Ƽ �۾� â�� �ִϸ��̼� �۾�â���� �ִϸ��̼� �̺�Ʈ�� �ֱ� ���� �Լ�
        protected void Return()
        {
            // ������ �� ��� �ִϸ��̼��� ������ ������� �ϱ� ���ؼ�
            StopAllCoroutines();
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            // �˹� ���� �ƴ� ��� �˹� ����
            if (!Isknockback)
            {
                StartCoroutine(_knockbackHandler.KnockbackCo());
            }
        }
    }
}