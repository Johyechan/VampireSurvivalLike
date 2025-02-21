using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private Calculator _calculator;

        public GameObject player;

        [HideInInspector] public bool groundMove = false;

        [HideInInspector] public int x = 9;

        [HideInInspector] public int y = 6;

        [HideInInspector] public int stage = 0;

        // 아이템 구분을 위한 식별번호
        [HideInInspector] public int itemNum = 0;

        protected override void Awake()
        {
            base.Awake();
            groundMove = false;
            itemNum = 0;
            _calculator = GetComponent<Calculator>();
        }

        public float AttackSpeedCalculate(float value, float probability)
        {
            return _calculator.AttackSpeedCalculate(value, probability);
        }

        public bool CalculatePercentageToBool(float probability)
        {
            return _calculator.CalculatePercentageToBool(probability);
        }
    }
}

