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

        // ������ ��ü�� transform�� ������ ����
        private Transform _trans;

        // �÷��̾��� ��ġ�� ������ ����
        private Vector3 _target;

        // ������ �ӵ�
        private float _speed;

        // ���� �������� �����ڿ��� �Ҵ�
        public EnemyMoveState(Animator animator, int hash, IEnemyMoveStrategy moveStrategy, Transform trans, Vector3 target, float speed)
        {
            _animator = animator;
            _hash = hash;
            _moveStrategy = moveStrategy;
            _trans = trans;
            _target = target;
            _speed = speed;
        }

        // �� ���°� �Ǿ��� ��
        public void Enter()
        {
            // ������ �ִϸ��̼� ����
            _animator.SetBool(_hash, true);
        }

        // �� ������ ����
        public void Execute()
        {
            Debug.Log("�� ������");

            // �÷��̾������ ������ ���ϱ�
            Vector2 dir = _target - _trans.position;

            // ������ ������ ���� �����̱�
            _moveStrategy.Move(_trans, dir, _speed);
        }

        public void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}

