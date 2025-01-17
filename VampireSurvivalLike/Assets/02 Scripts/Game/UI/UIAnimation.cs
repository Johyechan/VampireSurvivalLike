using Manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyUI
{
    public class UIAnimation : MonoBehaviour
    {
        public void FadeInOut(Image image, float delay, int target)
        {
            StartCoroutine(FadeInOutCo(image, delay, target));
        }

        public void FadeInOut(TMP_Text tmpText, float delay, int target)
        {
            StartCoroutine(FadeInOutCo(tmpText, delay, target));
        }

        public void FadeOutEnd(float delay, GameObject parent)
        {
            StartCoroutine(FadeOutEndCo(delay, parent));
        }

        public void AnimationEnd(float delay)
        {
            StartCoroutine(EndCo(delay));
        }

        private IEnumerator FadeInOutCo(Image image, float delay, int target = 0)
        {
            float curTime = 0;
            Color32 color = image.color;

            while (curTime < delay)
            {
                curTime += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(curTime / delay);
                image.color = Color32.Lerp(color, new Color32(color.r, color.g, color.b, (byte)target), t);
                yield return null;
            }

            image.color = new Color32(color.r, color.g, color.b, (byte)target);
            
        }

        private IEnumerator FadeInOutCo(TMP_Text tmpText, float delay, int target = 0)
        {
            float curTime = 0;
            Color32 color = tmpText.color;

            while (curTime < delay)
            {
                curTime += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(curTime / delay);
                tmpText.color = Color32.Lerp(color, new Color32(color.r, color.g, color.b, (byte)target), t);
                yield return null;
            }

            tmpText.color = new Color32(color.r, color.g, color.b, (byte)target);

        }

        private IEnumerator EndCo(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);

            UIManager.Instance.IsRunning = false;
        }

        private IEnumerator FadeOutEndCo(float delay, GameObject parent)
        {
            yield return new WaitForSecondsRealtime(delay);

            parent.SetActive(false);
            Time.timeScale = 1;
            UIManager.Instance.IsRunning = false;
        }
    }
}

