using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyUI
{
    public class UIAnimation : MonoBehaviour
    {
        public void Appear(Image[] images, float delay, int[] targets, GameObject parent = null)
        {
            StartCoroutine(ApperDisappearCo(images, images.Length, delay, targets, parent));
        }

        public void Disappear(Image[] images, float delay, GameObject parent = null)
        {
            int[] targets = new int[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                targets[i] = 0;
            }
            StartCoroutine(ApperDisappearCo(images, images.Length, delay, targets, parent));
        }

        private IEnumerator ApperDisappearCo(Image[] images, int count, float delay, int[] targets, GameObject parent = null)
        {
            UIManager.Instance.IsRunning = true;
            if (targets[0] != 0)
            {
                if (parent != null)
                {
                    parent.SetActive(true);
                }
            }

            float curTime = 0;
            Color32[] colors = new Color32[count];

            for (int i = 0; i < count; i++)
            {
                colors[i] = images[i].color;
            }

            while (curTime < delay)
            {
                curTime += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(curTime / delay);
                for (int i = 0; i < count; i++)
                {
                    if (colors[i] != Color.magenta && targets[i] != -1)
                    {
                        images[i].color = Color32.Lerp(colors[i], new Color32(colors[i].r, colors[i].g, colors[i].b, (byte)targets[i]), t);
                    }
                    else
                    {
                        if (images[i].gameObject.activeSelf)
                        {
                            images[i].gameObject.SetActive(false);
                        }
                    }
                }
                yield return null;
            }

            for (int i = 0; i < count; i++)
            {
                if (colors[i] != Color.magenta && targets[i] != -1)
                {
                    images[i].color = new Color32(colors[i].r, colors[i].g, colors[i].b, (byte)targets[i]);
                }
            }

            if (targets[0] == 0)
            {
                if (parent != null)
                {
                    parent.SetActive(false);
                    Time.timeScale = 1;
                }
            }

            UIManager.Instance.IsRunning = false;
        }
    }
}

