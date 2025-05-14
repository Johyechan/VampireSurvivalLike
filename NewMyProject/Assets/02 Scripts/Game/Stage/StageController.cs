using Manager;
using MyUI;
using TMPro;
using UnityEngine;

namespace Game.Stage
{
    // �ۼ���: ������
    // �ش� ������ ���������� ������ Ŭ����
    public class StageController : MonoBehaviour
    {
        private StageTimerHandler _timerHandler; // �������� Ÿ�̸�

        private StageUI _stageUI; // �������� Ÿ�̸� �� ���� �������� UI

        [SerializeField] private int _stageMinute; // �������� �ð�(��)
        [SerializeField] private int _stageSecond; // �������� �ð�(��)
        [SerializeField] private int _stageChangeDelay; // �������� ���� ��� �ð�(��)
        private int _currentStage;

        [SerializeField] TMP_Text _timerTMPText; // Ÿ�̸� �ؽ�Ʈ UI
        [SerializeField] TMP_Text _stageTMPText; // ���� �������� �ؽ�Ʈ UI

        // ���� �ʱ�ȭ
        private void Awake()
        {
            _timerHandler = new StageTimerHandler(_stageMinute, _stageSecond, _stageChangeDelay);
            _stageUI = new StageUI(_timerTMPText, _stageTMPText);
        }

        private void Start()
        {
            _currentStage = StageManager.Instance.CurrentStage; // ���� �������� ����
            _stageUI.CurrentStageUI(); // UI ����
            _stageUI.StageTimerUI(); // UI ����
            StartCoroutine(_timerHandler.StageTimer()); // �������� Ÿ�̸� ����
        }

        private void Update()
        {
            if (StageManager.Instance.LastStageEnd) // ���� ������ ���������� �����ٸ�
                _stageUI.BossStage(); // UI ���� ���������� ����
            else // ������ ���������� ������ �ʾҴٸ�
            {
                if(_currentStage !=  StageManager.Instance.CurrentStage) // ����� ���������� ���� ���������� �ƴ϶��
                {
                    _stageUI.CurrentStageUI(); // UI ����
                    _currentStage = StageManager.Instance.CurrentStage; // �������� ������
                }
                _stageUI.StageTimerUI(); // UI ����
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.14
