using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class StoreManager : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                Time.timeScale = 0;
                // ���ʿ��� ������ �� ������ �����ʿ��� �賶 ��
                // ���� ���� �г� ������ �ִϸ��̼� �Լ�
                // ������ �賶 �г� ������ �ִϸ��̼� �Լ�
            }
        }

        private void OutAnimation()
        {

        }
    }
}

