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
                // ���� UI�� �� ���� + ���� ����, ������ �賶
            }
        }
    }
}

