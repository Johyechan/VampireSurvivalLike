using Enemy.Boss;
using MyUtil;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Manager
{
    // 작성자: 조혜찬
    // 스테이지에 전체적으로 필요한 정보를 가지는 싱글톤 클래스
    public class StageManager : Singleton<StageManager>
    {
        public bool LastStageEnd { get; set; }
        public bool StageEnd { get; set; }
        public bool ChapterEnd { get; set; }

        private int _chapterCount;
        private int _stageCount = 1;

        public int CurrentMinute { get; set; }
        public int CurrentSecond { get; set; }

        public int CurrentStage { get; set; }

        [SerializeField] private int _maxStageCount;
        [SerializeField] private int _stageMinute;
        [SerializeField] private int _stageSecond;
        [SerializeField] private int _stageChangeTime;

        [SerializeField] private TMP_Text _timerTMPText;
        [SerializeField] private TMP_Text _stageTMPText;

        [SerializeField] private BossBase _stageBoss;

        protected override void Awake()
        {
            base.Awake();
            LastStageEnd = false;
            StageEnd = false;
            CurrentStage = 1;
        }

        private void Start()
        {
            StartCoroutine(Timer());

            _stageTMPText.text = $"Stage {_stageCount}";
        }

        private void Update()
        {
            if (_stageSecond < 10)
            {
                _timerTMPText.text = $"{_stageMinute}:0{_stageSecond}";
            }
            else
            {
                _timerTMPText.text = $"{_stageMinute}:{_stageSecond}";
            }
        }

        private IEnumerator Timer()
        {
            while (!GameManager.Instance.GameOver)
            {
                if(_stageCount >= _maxStageCount)
                {
                    _stageTMPText.text = "Boss Stage";
                    _timerTMPText.text = "";
                    break;
                }

                if (_stageMinute <= 0 && _stageSecond <= 0)
                {
                    if(StageEnd)
                    {
                        _stageTMPText.text = $"Stage {_stageCount}";
                    }
                    else
                    {
                        _stageCount++;
                        StageEnd = true;
                        _stageSecond = _stageChangeTime;
                    }
                }

                yield return new WaitForSeconds(1);
                if (_stageSecond <= 0)
                {
                    _stageMinute--;
                    _stageSecond = 59;
                }
                else
                {
                    _stageSecond -= 1;
                }
            }

            LastStageEnd = true;
        }
    }
}

