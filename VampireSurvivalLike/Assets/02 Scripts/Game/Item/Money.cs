using Pool;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Item
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private float _disappearTime;
        [SerializeField] private int _max;
        [SerializeField] private int _min;

        private int _moneyValue;

        public int moneyValue
        {
            get 
            { 
                return _moneyValue; 
            }
        }

        private void OnEnable()
        {
            _moneyValue = Random.Range(_min, _max + 1);
            StartCoroutine(DisappearCo());
        }

        private void OnDisable()
        {
            StopCoroutine(DisappearCo());
        }

        private IEnumerator DisappearCo()
        {
            float curTime = 0;
            while(curTime < _disappearTime)
            {
                curTime += Time.deltaTime;
                yield return null;
            }

            ObjectPoolManager.Instance.ReturnObject(ObjectPoolType.Money, gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                ObjectPoolManager.Instance.ReturnObject(ObjectPoolType.Money, gameObject);
            }
        }
    }
}

