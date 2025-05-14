using Manager;
using MyUI;
using TMPro;
using UnityEngine;

namespace Game.Stage
{
    // 작성자: 조혜찬
    // 해당 씬에서 스테이지를 관리할 클래스
    public class StageController : MonoBehaviour
    {
        private StageTimerHandler _timerHandler; // 스테이지 타이머

        private StageUI _stageUI; // 스테이지 타이머 및 현재 스테이지 UI

        [SerializeField] private int _stageMinute; // 스테이지 시간(분)
        [SerializeField] private int _stageSecond; // 스테이지 시간(초)
        [SerializeField] private int _stageChangeDelay; // 스테이지 변경 대기 시간(초)
        private int _currentStage;

        [SerializeField] TMP_Text _timerTMPText; // 타이머 텍스트 UI
        [SerializeField] TMP_Text _stageTMPText; // 현재 스테이지 텍스트 UI

        // 변수 초기화
        private void Awake()
        {
            _timerHandler = new StageTimerHandler(_stageMinute, _stageSecond, _stageChangeDelay);
            _stageUI = new StageUI(_timerTMPText, _stageTMPText);
        }

        private void Start()
        {
            _currentStage = StageManager.Instance.CurrentStage; // 현재 스테이지 저장
            _stageUI.CurrentStageUI(); // UI 변경
            _stageUI.StageTimerUI(); // UI 변경
            StartCoroutine(_timerHandler.StageTimer()); // 스테이지 타이머 실행
        }

        private void Update()
        {
            if (StageManager.Instance.LastStageEnd) // 만약 마지막 스테이지가 끝났다면
                _stageUI.BossStage(); // UI 보스 스테이지로 변경
            else // 마지막 스테이지가 끝나지 않았다면
            {
                if(_currentStage !=  StageManager.Instance.CurrentStage) // 저장된 스테이지가 현재 스테이지가 아니라면
                {
                    _stageUI.CurrentStageUI(); // UI 변경
                    _currentStage = StageManager.Instance.CurrentStage; // 스테이지 재저장
                }
                _stageUI.StageTimerUI(); // UI 변경
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.14
