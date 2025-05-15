using UnityEngine;
using MyUtil;
using TMPro;
using System.Collections;

namespace Manager
{
    // 작성자: 조혜찬
    // 게임 매니저 싱글톤 클래스
    public class GameManager : Singleton<GameManager>
    {
        public GameObject player; // 플레이어 오브젝트

        public Vector2 PlayerMoveDir { get; set; } // 플레이어 이동 방향

        public bool GameOver { get; set; } // 게임 종료 여부

        public int NameNum { get; set; } // 딕셔너리에 오브젝트를 넣을 때 키 값의 중복을 막기 위해 각 오브젝트마다 주는 고유 번호

        // 변수 초기화 및 인스턴스 초기화
        protected override void Awake()
        {
            base.Awake();
            NameNum = 0;
            GameOver = false;
        }
    }
}
// 마지막 작성 일자: 2025.05.15
