using Manager;
using MyUtil.Interface;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public float MaxHp { get; set; }
        private float _currentHp;

        public bool IsHit { get; set; }
        public bool IsDie { get; private set; }

        private void OnEnable()
        {
            IsHit = false;
            IsDie = false;
        }

        void Start()
        {
            _currentHp = MaxHp;
        }

        void Update()
        {

        }

        protected void Die()
        {
            GameManager.Instance.gameOver = true;
            Time.timeScale = 0;
        }

        public void TakeDamage(float damage)
        {
            if(!IsDie)
            {
                if (_currentHp > 0)
                {
                    Debug.Log($"플레이어 {damage} 받음");
                    _currentHp -= damage;
                    IsHit = true;
                }
                else
                {
                    IsDie = true;
                }
            }
        }
    }

}
