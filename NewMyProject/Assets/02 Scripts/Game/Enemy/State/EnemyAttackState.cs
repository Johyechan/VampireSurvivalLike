using Enemy.Interface;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyAttackState : IState
    {
        // ���� �ִϸ��̼��� �����ϱ� ���� �ִϸ����� ����
        private Animator _animator;

        // ���� �ִϸ��̼��� �����ϱ� ���� �ؽ� ����
        private int _hash;

        // ���� ���� ������ �ٰŸ� �Ǵ� ���Ÿ�
        private IEnemyAttackStrategy _attackStrategy;

        // �����ڿ��� ���� �ʿ��� ������ �޾Ƽ� �Ҵ�
        public EnemyAttackState(Animator animator, int hash, IEnemyAttackStrategy attackStrategy)
        {
            _animator = animator;
            _hash = hash;
            _attackStrategy = attackStrategy;
        }

        // �� ���¿� ������ ��
        public void Enter()
        {
            Debug.Log("�� ����");

            // ������ �´� ���� ������� ���� ���
            _attackStrategy.Attack();
            // ���� �ִϸ��̼� ����
            _animator.SetTrigger(_hash);
        }

        // �� ������ ����
        public void Execute()
        {
            
        }

        // �� ���¿��� ���� ���� ��
        public void Exit()
        {
            
        }
    }
}

