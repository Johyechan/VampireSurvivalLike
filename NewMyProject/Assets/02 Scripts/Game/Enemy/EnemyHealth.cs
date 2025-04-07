using MyUtil.Interface;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        private EnemyBase _enemyBase;

        public float MaxHp { get; set; }
        private float _currentHp;

        private void Awake()
        {
            _enemyBase = GetComponent<EnemyBase>();
        }

        private void Start()
        {
            _currentHp = MaxHp;
        }

        public void TakeDamage(float damage)
        {
            if (_currentHp > 0)
            {
                _currentHp -= damage;
            }

            if (_currentHp < 0)
            {
                _enemyBase.Death();
            }
            else
            {
                _enemyBase.Hit();
            }
        }
    }
}

