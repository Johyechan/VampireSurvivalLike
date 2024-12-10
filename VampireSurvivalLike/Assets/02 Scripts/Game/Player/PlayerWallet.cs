using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerWallet : MonoBehaviour
    {
        private int _currentMoney;
        public int currentMoney
        {
            get
            {
                return _currentMoney;
            }
        }

        private void Start()
        {
            _currentMoney = 0;
        }

        public void AddMoney(int moneyValue)
        {
            _currentMoney += moneyValue;
            Debug.Log($"current Money: {_currentMoney}$");
        }

        public void RemoveMoney(int moneyValue)
        {
            if(_currentMoney < moneyValue)
            {
                Debug.Log("You need more money");
                return;
            }

            _currentMoney -= moneyValue;
        }
    }
}

