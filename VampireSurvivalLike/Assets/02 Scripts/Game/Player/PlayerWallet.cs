using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Manager;

namespace Player
{
    public class PlayerWallet : MonoBehaviour, IEventListener<int>
    {
        private int _currentMoney;

        private void Start()
        {
            _currentMoney = GameManager.Instance.player.GetComponent<PlayerController>().so.startMoney;
            GameEventManager.OnMoneyUIEvent.EventCall(_currentMoney);
        }

        private void OnEnable()
        {
            GameEventManager.OnMoneyUseEvent.AddEvent(this);
        }

        private void OnDisable()
        {
            GameEventManager.OnMoneyUseEvent.RemoveEvent(this);
        }

        private bool ChangeMoney(int minusOrPlusMoneyValue)
        {
            if(minusOrPlusMoneyValue < 0)
            {
                if (_currentMoney < minusOrPlusMoneyValue)
                {
                    return false;
                }

                _currentMoney += minusOrPlusMoneyValue;

                return true;
            }
            else
            {
                _currentMoney += minusOrPlusMoneyValue;
                return true;
            }
        }

        public void OnEvent(int t)
        {
            if(ChangeMoney(t))
            {
                GameEventManager.OnMoneyUIEvent.EventCall(_currentMoney);
            }
            else
            {
                Debug.Log("µ·ÀÌ ÀûÀ½");
            }
        }
    }
}

