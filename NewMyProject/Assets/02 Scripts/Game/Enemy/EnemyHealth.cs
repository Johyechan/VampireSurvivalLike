using MyUtil.Interface;
using UnityEngine;

namespace Enemy
{
    // ���� ü���� �������� �����ϴ� Ŭ����
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        // ���� �⺻ Ŭ������ �������� ������ �ǰ� ���� �� ��� ���·� ���� ���̸� �ϱ� ����
        private EnemyBase _enemyBase;

        // �ִ� ü���� ���صΰ�
        public float MaxHp { get; set; }
        // ���� ü���� ������ �� �ִ� ü������ ���� �׸��� ��� ���¸� Ȯ���ϱ� ���� �����ϴ� ����
        private float _currentHp;

        private void Awake()
        {
            // �ʿ��� Ŭ������ ������
            _enemyBase = GetComponent<EnemyBase>();
        }

        private void Start()
        {
            // ü�� �ʱ�ȭ
            _currentHp = MaxHp;
        }

        // �������� �޾��� ��
        public void TakeDamage(float damage)
        {
            // ���� ü���� 0 �̻��� ���� ü�� ����
            if (_currentHp > 0)
            {
                _currentHp -= damage;
            }
            
            if (_currentHp < 0) // ü���� 0���� ���ٸ� ���
            {
                _enemyBase.Death();
            }
            else // ���ٸ� �ǰ� ���·� ����
            {
                _enemyBase.Hit();
            }
        }
    }
}

