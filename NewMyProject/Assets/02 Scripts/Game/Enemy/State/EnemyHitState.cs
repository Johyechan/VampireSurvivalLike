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

        // �з��� ������ �����ϴ� ����
        private Vector2 dir;

        // �з��� ������Ʈ�� �����ϴ� ����
        private Transform _trans;

        // �з����� �Ŀ�
        private float _knockbackPower;

        // �����忡�� ���� ������ �ʿ��� ������ �޾Ƽ� �Ҵ�
        public EnemyHitState(Animator animator, int hash, Transform trans, float knockbackPower)
        {
            _animator = animator;
            _hash = hash;
            _trans = trans;
            _knockbackPower = knockbackPower;
        }

        // �� ���¿� ������ ��
        public void Enter()
        {
            // �ִϸ��̼� ����
            _animator.SetTrigger(_hash);

            // �з����� ���� ���� - �÷��̾�κ��� �ڽ��� �������� �з����� ������ ����
            dir = (_trans.position - GameManager.Instance.player.transform.position).normalized;
        }

        // �� ������ ����
        public void Execute()
        {
            // �з����� ����
            _trans.position += (Vector3)(dir.normalized * _knockbackPower * Time.deltaTime);
        }

        // �� ���¿��� ���� ���� ��
        public void Exit()
        {
            
        }
    }
}

