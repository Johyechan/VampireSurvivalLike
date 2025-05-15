using UnityEngine;
using MyUtil;
using TMPro;
using System.Collections;

namespace Manager
{
    // �ۼ���: ������
    // ���� �Ŵ��� �̱��� Ŭ����
    public class GameManager : Singleton<GameManager>
    {
        public GameObject player; // �÷��̾� ������Ʈ

        public Vector2 PlayerMoveDir { get; set; } // �÷��̾� �̵� ����

        public bool GameOver { get; set; } // ���� ���� ����

        public int NameNum { get; set; } // ��ųʸ��� ������Ʈ�� ���� �� Ű ���� �ߺ��� ���� ���� �� ������Ʈ���� �ִ� ���� ��ȣ

        // ���� �ʱ�ȭ �� �ν��Ͻ� �ʱ�ȭ
        protected override void Awake()
        {
            base.Awake();
            NameNum = 0;
            GameOver = false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.15
