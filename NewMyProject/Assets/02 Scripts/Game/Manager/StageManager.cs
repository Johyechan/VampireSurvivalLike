using Enemy.Boss;
using MyUtil;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Manager
{
    public class StageManager : Singleton<StageManager>
    {
        public bool StageEnd { get; set; }

        [SerializeField] private int _minute;
        [SerializeField] private int _second;

        [SerializeField] private TMP_Text _timerTMPText;

        [SerializeField] private BossBase _stageBoss;

        protected override void Awake()
        {
            base.Awake();
            StageEnd = false;
        }

        private void Start()
        {
            StartCoroutine(Timer());
        }

        private void Update()
        {
            if (_second < 10)
            {
                _timerTMPText.text = $"{_minute}:0{_second}";
            }
            else
            {
                _timerTMPText.text = $"{_minute}:{_second}";
            }
        }

        private IEnumerator Timer()
        {
            while (!GameManager.Instance.GameOver)
            {
                if (_minute <= 0 && _second <= 0)
                    break;

                yield return new WaitForSeconds(1);
                if (_second <= 0)
                {
                    _minute--;
                    _second = 59;
                }
                else
                {
                    _second -= 1;
                }
            }

            StageEnd = true;
        }
    }
}

