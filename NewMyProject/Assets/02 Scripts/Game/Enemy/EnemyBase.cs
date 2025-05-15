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
    // �ۼ���: ������
    // ���� �⺻������ ������ �� ��ɵ��� ���� Ŭ����
    public abstract class EnemyBase : EnemyBaseVariables
    {
        // �����
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _so.attackRange); // ���� ����
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _so.playerCheckRange); // �÷��̾� ã�� ����
        }

        protected virtual void OnEnable()
        {
            // �ʱ�ȭ�� ���� �׻� ���Ӱ� �����Ǹ� �� ������Ʈ Ǯ���� ���Ӱ� �������� ��� ����ִ� ����
            IsAttackDelay = false;
            Isknockback = false;
            // �׸��� �⺻ ���·� ���� ��ȯ
            _machine.ChangeState(_idleState);
        }

        void Update()
        {
            // Update���� �ݺ������� �� ������ Execute�� ����
            if(GameManager.Instance.GameOver)
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
            GameObject money = ObjectPoolManager.Instance.GetObject(ObjectPoolType.Money);
            money.transform.position = transform.position;
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