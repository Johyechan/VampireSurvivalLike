using Manager;
using TMPro;
using UnityEngine;

namespace MyUI
{
    // 작성자: 조혜찬
    // 스테이지 UI를 담당하는 클래스
    public class StageUI
    {
        private TMP_Text _timerTMPText; // 시간을 보여줄 텍스트 UI
        private TMP_Text _stageTMPText; // 현재 스테이지를 보여줄 텍스트 UI

        // 생성자에서 변수 초기화
        public StageUI(TMP_Text timerTMPText, TMP_Text stageTMPText)
        {
            _timerTMPText = timerTMPText;
            _stageTMPText = stageTMPText;
        }

        // 현재 스테이지 UI
        public void CurrentStageUI()
        {
            _stageTMPText.text = $"Stage {StageManager.Instance.CurrentStage}"; // 현재 스테이지 UI에 띄우기
        }

        // 보스 스테이지 UI
        public void BossStage()
        {
            _stageTMPText.text = "Boss Stage";
            _timerTMPText.text = "";
        }

        // 현재 스테이지 타이머 UI
        public void StageTimerUI()
        {
            if (StageManager.Instance.CurrentSecond < 10) // 만약 스테이지 타이머에서 초가 10 보다 작다면
            {
                _timerTMPText.text = $"{StageManager.Instance.CurrentMinute} : 0{StageManager.Instance.CurrentSecond}"; // 초에서 현재 초 앞에 0 붙이기
            }
            else // 아니라면
            {
                _timerTMPText.text = $"{StageManager.Instance.CurrentMinute} : {StageManager.Instance.CurrentSecond}"; // 그대로
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.14
