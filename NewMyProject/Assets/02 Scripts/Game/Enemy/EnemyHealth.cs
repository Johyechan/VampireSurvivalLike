using MyUtil.Interface;
using UnityEngine;

namespace Enemy
{
    // 적의 체력을 전적으로 관리하는 클래스
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        // 최대 체력을 정해두고
        public float MaxHp { get; set; }
        // 현재 체력은 시작할 때 최대 체력으로 정함 그리고 사망 상태를 확인하기 위해 존재하는 변수
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
            // 체력 초기화
            _currentHp = MaxHp;
        }

        // 데미지를 받았을 때
        public void TakeDamage(float damage)
        {
            if(!IsDie)
            {
                // 현재 체력이 0 이상일 때만 체력 감소
                if (_currentHp > 0)
                {
                    Debug.Log(damage);
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

