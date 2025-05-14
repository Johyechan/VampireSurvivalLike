using Manager;
using TMPro;
using UnityEngine;

namespace MyUI
{
    // �ۼ���: ������
    // �������� UI�� ����ϴ� Ŭ����
    public class StageUI
    {
        private TMP_Text _timerTMPText; // �ð��� ������ �ؽ�Ʈ UI
        private TMP_Text _stageTMPText; // ���� ���������� ������ �ؽ�Ʈ UI

        // �����ڿ��� ���� �ʱ�ȭ
        public StageUI(TMP_Text timerTMPText, TMP_Text stageTMPText)
        {
            _timerTMPText = timerTMPText;
            _stageTMPText = stageTMPText;
        }

        // ���� �������� UI
        public void CurrentStageUI()
        {
            _stageTMPText.text = $"Stage {StageManager.Instance.CurrentStage}"; // ���� �������� UI�� ����
        }

        // ���� �������� UI
        public void BossStage()
        {
            _stageTMPText.text = "Boss Stage";
            _timerTMPText.text = "";
        }

        // ���� �������� Ÿ�̸� UI
        public void StageTimerUI()
        {
            if (StageManager.Instance.CurrentSecond < 10) // ���� �������� Ÿ�̸ӿ��� �ʰ� 10 ���� �۴ٸ�
            {
                _timerTMPText.text = $"{StageManager.Instance.CurrentMinute} : 0{StageManager.Instance.CurrentSecond}"; // �ʿ��� ���� �� �տ� 0 ���̱�
            }
            else // �ƴ϶��
            {
                _timerTMPText.text = $"{StageManager.Instance.CurrentMinute} : {StageManager.Instance.CurrentSecond}"; // �״��
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.14
