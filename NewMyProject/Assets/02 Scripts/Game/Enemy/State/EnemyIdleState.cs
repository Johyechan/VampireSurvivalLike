using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyIdleState : IState
    {
        // idle �ִϸ��̼��� �����Ű�� ���� animator ����
        private Animator _animator;

        // idle �ִϸ��̼��� �����Ű�� ���� �ؽ� ����
        private int _hash;

        // ���� �������� �ʱ�ȭ ���ֱ� ���� ������
        public EnemyIdleState(Animator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }

        // �� ���¿� ������ ��
        public void Enter()
        {
            // �ִϸ��̼� ����
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

