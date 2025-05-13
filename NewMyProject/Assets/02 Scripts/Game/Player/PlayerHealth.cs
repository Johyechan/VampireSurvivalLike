using Manager;
using MyUtil.Interface;
using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public float MaxHp { get; set; }
        private float _currentHp;

        public bool IsHit { get; set; }
        public bool IsDie { get; private set; }

        private bool _isNoHitTime;

        private Coroutine _currentCoroutine;

        public event Action OnHit;
        public event Action OnDie;

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
            GameManager.Instance.GameOver = true;
            Time.timeScale = 0;
        }

        public void TakeDamage(float damage)
        {
            if(!IsDie && !_isNoHitTime)
            {
                if (_currentHp > 0)
                {
                    _currentHp -= damage;

                    if (_currentCoroutine != null)
                        StopCoroutine(_currentCoroutine);

                    _currentCoroutine = StartCoroutine(NoHitTimerCo());
                    if(_currentHp <= 0)
                    {
                        OnDie?.Invoke();
                        IsDie = true;
                    }
                    else
                    {
                        OnHit?.Invoke();
                        IsHit = true;
                    }
                }
                else
                {
                    OnDie?.Invoke();
                    IsDie = true;
                }
            }
        }

        private IEnumerator NoHitTimerCo()
        {
            _isNoHitTime = true;
            yield return new WaitForSeconds(0.3f);
            _isNoHitTime = false;
        }
    }

}
