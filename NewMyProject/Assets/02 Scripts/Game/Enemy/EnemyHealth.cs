using MyUtil.Interface;
using UnityEngine;

namespace Enemy
{
    // 적의 체력을 전적으로 관리하는 클래스
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        // 적의 기본 클래스를 가져오는 이유는 피격 상태 및 사망 상태로 상태 전이를 하기 위함
        private EnemyBase _enemyBase;

        // 최대 체력을 정해두고
        public float MaxHp { get; set; }
        // 현재 체력은 시작할 때 최대 체력으로 정함 그리고 사망 상태를 확인하기 위해 존재하는 변수
        private float _currentHp;

        private void Awake()
        {
            // 필요한 클래스를 가져옴
            _enemyBase = GetComponent<EnemyBase>();
        }

        private void Start()
        {
            // 체력 초기화
            _currentHp = MaxHp;
        }

        // 데미지를 받았을 때
        public void TakeDamage(float damage)
        {
            // 현재 체력이 0 이상일 때만 체력 감소
            if (_currentHp > 0)
            {
                _currentHp -= damage;
            }
            
            if (_currentHp < 0) // 체력이 0보다 적다면 사망
            {
                _enemyBase.Death();
            }
            else // 많다면 피격 상태로 전이
            {
                _enemyBase.Hit();
            }
        }
    }
}

