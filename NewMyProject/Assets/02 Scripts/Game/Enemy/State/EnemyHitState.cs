using Manager;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyHitState : IState
    {
        // ���� ������ �� �ִϸ��̼��� ���� ��Ű�� ���� �ִϸ����� ����
        private Animator _animator;

        // �ִϸ��̼��� ���� ��Ű�� ���� �ؽ� ����
        private int _hash;

        // �����忡�� ���� ������ �ʿ��� ������ �޾Ƽ� �Ҵ�
        public EnemyHitState(Animator animator, int hash)
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

