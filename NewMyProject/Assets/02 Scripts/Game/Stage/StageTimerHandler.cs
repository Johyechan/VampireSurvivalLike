using Manager;
using System.Collections;
using UnityEngine;

namespace Game.Stage
{
    // �ۼ���: ������
    // �������� �ð��� �����ϴ� Ŭ����
    public class StageTimerHandler
    {
        private int _minute; // �������� �ð�(��)
        private int _second; // �������� �ð�(��)
        private int _stageChangeDelay; // �������� ���� ��� �ð�(��)

        // �����ڿ��� ���� �ʱ�ȭ �� �ð� �ʱ�ȭ
        public StageTimerHandler(int  minute, int second, int stageChangeDelay)
        {
            _minute = minute;
            _second = second;
            _stageChangeDelay = stageChangeDelay;

            StageTimerSet();
        }

        // �������� Ÿ�̸�
        public IEnumerator StageTimer()
        {
            while (!GameManager.Instance.GameOver) // �÷��̾ �ױ� ������ �ݺ�
            {
                if (StageManager.Instance.LastStageEnd)
                    break;

                if (StageManager.Instance.CurrentMinute <= 0 && StageManager.Instance.CurrentSecond <= 0) // ���� �ð��� 0�� �� ���
                {
                    StageManager.Instance.StageEnd = !StageManager.Instance.StageEnd;

                    StageTimerSet();

                    if(!StageManager.Instance.StageEnd)
                    {
                        StageManager.Instance.CurrentStage++;
                    }
                }

                yield return new WaitForSeconds(1); // �ʴ� 1�� ���̱� ���ؼ� 1�� ���

                if (StageManager.Instance.CurrentSecond <= 0) // �ʰ� 0 ���϶��
                {
                    StageManager.Instance.CurrentMinute--; // ���� ���̰�
                    StageManager.Instance.CurrentSecond = 59; // �ʸ� 59�� ����
                }
                else // ���� �ʰ� 0���� ũ�ٸ�
                {
                    StageManager.Instance.CurrentSecond--; // 1�� ���̱�
                }
            }
        }

        private void StageTimerSet()
        {
            if(StageManager.Instance.StageEnd)
            {
                StageManager.Instance.CurrentMinute = 0; // ���� 0���� �ʱ�ȭ
                StageManager.Instance.CurrentSecond = _stageChangeDelay; // �ʸ� ���� ��� �ð����� �ʱ�ȭ
            }
            else
            {
                StageManager.Instance.CurrentMinute = _minute; // ���� �������� �ð�(��)���� �ʱ�ȭ
                StageManager.Instance.CurrentSecond = _second; // ���� �������� �ð�(��)���� �ʱ�ȭ
            }
                
        }
    }
}
// ������ �ۼ� ����: 2025.05.14
