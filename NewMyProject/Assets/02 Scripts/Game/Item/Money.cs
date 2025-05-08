using UnityEngine;

namespace Item
{
    public class Money : MonoBehaviour
    {
        public int MoneyValue { get; private set; }

        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        private void OnEnable()
        {
            MoneyValue = Random.Range(_minValue, _maxValue + 1);
        }
    }
}

