using Manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyUI
{
    public class UIController : MonoBehaviour
    {
        public bool isNotStartEnable;

        public bool isImage;

        public int alphaValue;

        public void ChangeAlpha(bool isAppear, float delay = 0)
        {
            int alpha = 0;

            if(isAppear)
            {
                alpha = alphaValue;
            }
            
            if(delay == 0)
            {
                delay = UIManager.Instance.delay;
            }

            if(isImage)
            {
                Image image = GetComponent<Image>();
                UIManager.Instance.FadeInOut(image, delay, alpha);
            }
            else
            {
                TMP_Text tmpText = GetComponent<TMP_Text>();
                UIManager.Instance.FadeInOut(tmpText, delay, alpha);
            }
        }
    }

}
