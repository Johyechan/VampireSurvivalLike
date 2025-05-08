using MyUtil.FSM;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyDeathState : IState
    {
        // ��� �ִϸ��̼��� �����ϱ� ���� �ִϸ����� ����
        private Animator _animator;

        // ��� �ִϸ��̼��� �����ϱ� ���� �ؽ� ����
        private int _hash;

        // ���� �����鿡 �ʿ��� ������ �޾Ƽ� �Ҵ�
        public EnemyDeathState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        // �� ���¿� ������ ��
        public void Enter()
        {
            // �ִϸ��̼� ����
            Debug.Log("�� ���");
            _animator.SetTrigger(_hash);
        }

        // �� ������ ����
        public void Execute()
        {
            
        }

        // �� ���¿��� �������� ��
        public void Exit()
        {
            
        }
    }
}

