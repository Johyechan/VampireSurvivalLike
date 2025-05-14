using Manager;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy
{
    // ���� ü���� �������� �����ϴ� Ŭ����
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        // �ִ� ü���� ���صΰ�
        public float MaxHp { get; set; }
        // ���� ü���� ������ �� �ִ� ü������ ���� �׸��� ��� ���¸� Ȯ���ϱ� ���� �����ϴ� ����
        private float _currentHp;

        public bool IsHit { get; set; }
        public bool IsDie { get; private set; }

        private void OnEnable()
        {
            IsHit = false;
            IsDie = false;
        }

        private void Start()
        {
            // ü�� �ʱ�ȭ
            _currentHp = MaxHp;
        }

        private void Update()
        {
            if(StageManager.Instance.StageEnd)
            {
                IsDie = true;
            }
        }

        // �������� �޾��� ��
        public void TakeDamage(float damage)
        {
            if(!IsDie)
            {
                // ���� ü���� 0 �̻��� ���� ü�� ����
                if (_currentHp > 0)
                {
                    _currentHp -= damage;
                    if(_currentHp <= 0)
                    {
                        IsDie = true;
                    }
                    else
                    {
                        IsHit = true;
                    } 
                }
                else
                {
                    IsDie = true;
                }
            }
        }
    }
}

