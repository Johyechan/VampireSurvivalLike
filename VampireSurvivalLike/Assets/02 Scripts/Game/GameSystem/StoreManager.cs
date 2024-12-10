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
                // »óÁ¡ UI°¡ µü ³ª¿È + ¿ÞÂÊ »óÁ¡, ¿À¸¥ÂÊ ¹è³¶
            }
        }
    }
}

