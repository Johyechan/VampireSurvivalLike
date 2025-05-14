using UnityEngine;

namespace Game.Stage
{
    // �ۼ���: ������
    // �ش� ������ ���������� ������ Ŭ����
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
// ������ �ۼ� ����: 2025.05.14
