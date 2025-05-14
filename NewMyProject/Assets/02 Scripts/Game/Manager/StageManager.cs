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
        public bool LastStageEnd { get; set; } // 마지막 스테이지 종료 여부를 판단하는 프로퍼티
        public bool StageEnd { get; set; } // 스테이지 종료 여부를 판단하는 프로퍼티

        public int CurrentMinute { get; set; } // 현재 시간(분) 프로퍼티
        public int CurrentSecond { get; set; } // 현재 시간(초) 프로퍼티
        public int CurrentStage { get; set; } // 현재 스테이지 프로퍼티

        [SerializeField] private int _maxStageCount; // 스테이지 수

        // 변수 초기화
        protected override void Awake()
        {
            base.Awake();
            LastStageEnd = false; // 마지막 스테이지 종료 X
            StageEnd = false; // 스테이지 종료 X
            CurrentStage = 1; // 현재 스테이지를 1로 설정
        }

        private void Update()
        {
            if (CurrentStage > _maxStageCount) // 만약 현재 스테이지가 스테이지 수보다 크다면 마지막 스테이지 종료 
                LastStageEnd = true;
        }
    }
}

