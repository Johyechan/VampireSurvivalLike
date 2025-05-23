using Manager;
using System.Collections;
using UnityEngine;

namespace Game.Stage
{
    // 작성자: 조혜찬
    // 스테이지 시간을 관리하는 클래스
    public class StageTimerHandler
    {
        private int _minute; // 스테이지 시간(분)
        private int _second; // 스테이지 시간(초)
        private int _stageChangeDelay; // 스테이지 변경 대기 시간(초)

        // 생성자에서 변수 초기화 및 시간 초기화
        public StageTimerHandler(int  minute, int second, int stageChangeDelay)
        {
            _minute = minute;
            _second = second;
            _stageChangeDelay = stageChangeDelay;

            StageTimerSet();
        }

        // 스테이지 타이머
        public IEnumerator StageTimer()
        {
            while (!GameManager.Instance.GameOver) // 플레이어가 죽기 전까지 반복
            {
                if (StageManager.Instance.LastStageEnd)
                    break;

                if (StageManager.Instance.CurrentMinute <= 0 && StageManager.Instance.CurrentSecond <= 0) // 만약 시간이 0이 된 경우
                {
                    StageManager.Instance.StageEnd = !StageManager.Instance.StageEnd;

                    StageTimerSet();

                    if(!StageManager.Instance.StageEnd)
                    {
                        StageManager.Instance.CurrentStage++;
                    }
                }

                yield return new WaitForSeconds(1); // 초당 1씩 줄이기 위해서 1초 대기

                if (StageManager.Instance.CurrentSecond <= 0) // 초가 0 이하라면
                {
                    StageManager.Instance.CurrentMinute--; // 분을 줄이고
                    StageManager.Instance.CurrentSecond = 59; // 초를 59로 변경
                }
                else // 만약 초가 0보다 크다면
                {
                    StageManager.Instance.CurrentSecond--; // 1씩 줄이기
                }
            }
        }

        private void StageTimerSet()
        {
            if(StageManager.Instance.StageEnd)
            {
                StageManager.Instance.CurrentMinute = 0; // 분을 0으로 초기화
                StageManager.Instance.CurrentSecond = _stageChangeDelay; // 초를 변경 대기 시간으로 초기화
            }
            else
            {
                StageManager.Instance.CurrentMinute = _minute; // 원래 스테이지 시간(분)으로 초기화
                StageManager.Instance.CurrentSecond = _second; // 원래 스테이지 시간(초)으로 초기화
            }
                
        }
    }
}
// 마지막 작성 일자: 2025.05.14
