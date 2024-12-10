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
                // 왼쪽에서 상점일 쏵 나오고 오른쪽에서 배낭 쏵
                // 왼쪽 상점 패널 나오는 애니메이션 함수
                // 오른쪽 배낭 패널 나오는 애니메이션 함수
            }
        }

        private void OutAnimation()
        {

        }
    }
}

