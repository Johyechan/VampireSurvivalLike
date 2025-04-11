using Enemy.Interface;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyMoveState : IState
    {
        // move �ִϸ��̼��� ���� ��Ű�� ���� animator ����
        private Animator _animator;

        // move �ִϸ��̼��� ���� ��Ű�� ���� �ؽ� ����
        private int _hash;

        // ������ ���� ���� (�÷��̾� ����ٴϴ� ������ �Ǵ� ��Ʈ�� ������ (�� ���� ������ ���� �� ����)
        private IEnemyMoveStrategy _moveStrategy;

        // ���� �������� �����ڿ��� �Ҵ�
        public EnemyMoveState(Animator animator, int hash, IEnemyMoveStrategy moveStrategy)
        {
            _animator = animator;
            _hash = hash;
            _moveStrategy = moveStrategy;
        }

        // �� ���¿� ������ ��
        public void Enter()
        {
            // ������ �ִϸ��̼� ����
            _animator.SetBool(_hash, true);
        }

        // �� ������ ����
        public void Execute()
        {
            // ������ ������ ���� �����̱�
            _moveStrategy.Move();
        }

        // �� ���¿��� �������� ��
        public void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}

