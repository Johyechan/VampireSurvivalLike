using UnityEngine;

namespace Game.Stage
{
    // 작성자: 조혜찬
    // 해당 씬에서 스테이지를 관리할 클래스
    public class StageController : MonoBehaviour
    {
        private StageTimerHandler _timerHandler;

        [SerializeField] private int _stageMinute;
        [SerializeField] private int _stageSecond;
        [SerializeField] private int _stageChangeDelay;

        private void Awake()
        {
            _timerHandler = new StageTimerHandler(_stageMinute, _stageSecond, _stageChangeDelay);
        }

        private void Start()
        {
            StartCoroutine(_timerHandler.StageTimer());
        }
    }
}
// 마지막 작성 일자: 2025.05.14
