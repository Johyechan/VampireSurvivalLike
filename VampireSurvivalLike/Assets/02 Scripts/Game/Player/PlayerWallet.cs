using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Manager;

namespace Player
{
    public class PlayerWallet : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;

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
            _currentMoney = GameManager.Instance.player.GetComponent<PlayerController>().so.startMoney;
            _tmpText.text = "X " + _currentMoney.ToString();
        }

        public void AddMoney(int moneyValue)
        {
            _currentMoney += moneyValue;
            Debug.Log($"current Money: {_currentMoney}$");
            _tmpText.text = "X " + _currentMoney.ToString();
        }

        public bool UseMoney(int moneyValue)
        {
            if(_currentMoney < moneyValue)
            {
                Debug.Log("You need more money");
                return false;
            }

            _currentMoney -= moneyValue;
            _tmpText.text = "X " + _currentMoney.ToString();
            return true;
        }
    }
}

