using Enemy.Boss;
using MyUtil;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Manager
{
    // �ۼ���: ������
    // ���������� ��ü������ �ʿ��� ������ ������ �̱��� Ŭ����
    public class StageManager : Singleton<StageManager>
    {
        public bool LastStageEnd { get; set; } // ������ �������� ���� ���θ� �Ǵ��ϴ� ������Ƽ
        public bool StageEnd { get; set; } // �������� ���� ���θ� �Ǵ��ϴ� ������Ƽ

        public int CurrentMinute { get; set; } // ���� �ð�(��) ������Ƽ
        public int CurrentSecond { get; set; } // ���� �ð�(��) ������Ƽ
        public int CurrentStage { get; set; } // ���� �������� ������Ƽ

        [SerializeField] private int _maxStageCount; // �������� ��

        // ���� �ʱ�ȭ
        protected override void Awake()
        {
            base.Awake();
            LastStageEnd = false; // ������ �������� ���� X
            StageEnd = false; // �������� ���� X
            CurrentStage = 1; // ���� ���������� 1�� ����
        }

        private void Update()
        {
            if (CurrentStage > _maxStageCount) // ���� ���� ���������� �������� ������ ũ�ٸ� ������ �������� ���� 
                LastStageEnd = true;
        }
    }
}

