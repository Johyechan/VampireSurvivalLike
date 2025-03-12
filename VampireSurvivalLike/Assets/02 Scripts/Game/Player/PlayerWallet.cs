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

        private MoneyEvent _onMoneyEvent;

        private void Start()
        {
            _currentMoney = GameManager.Instance.player.GetComponent<PlayerController>().so.startMoney;
            _onMoneyEvent.EventCall(_currentMoney);
        }

        public void AddMoney(int moneyValue)
        {
            _currentMoney += moneyValue;
            _onMoneyEvent.EventCall(_currentMoney);
        }

        public bool UseMoney(int moneyValue)
        {
            if(_currentMoney < moneyValue)
            {
                return false;
            }

            _currentMoney -= moneyValue;
            _onMoneyEvent.EventCall(_currentMoney);
            return true;
        }
    }
}

