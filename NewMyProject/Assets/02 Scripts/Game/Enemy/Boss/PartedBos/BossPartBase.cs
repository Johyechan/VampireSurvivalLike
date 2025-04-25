using Enemy.Boss.Interface;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public class BossPartBase : MonoBehaviour, IBossPart, IDamageable
    {
        public float MaxHp {  get; set; }
        protected float _currentHp;

        public bool IsDestroy { get; private set; }

        public List<IBossPattern> Patterns { get; protected set; }

        private void Start()
        {
            _currentHp = MaxHp;
        }

        public IBossPattern RandomPattern()
        {
            int randomIndex = Random.Range(0, Patterns.Count);
            return Patterns[randomIndex];
        }

        public void TakeDamage(float damage)
        {
            if(_currentHp > 0)
            {
                _currentHp -= damage;
            }
            else
            {
                IsDestroy = true;
            }
        }
    }
}

