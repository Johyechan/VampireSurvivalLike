using Pool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoSingleton<UIManager>
    {
        private bool _isRunning = false;
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
        }

        public void Appear(Image[] images, float delay, int[] targets, GameObject parent = null)
        {
            StartCoroutine(ApperDisappearCo(images, images.Length, delay, targets, parent));
        }

        public void Disappear(Image[] images, float delay, GameObject parent = null)
        {
            int[] targets = new int[images.Length];
            for(int i = 0;  i < images.Length; i++)
            {
                targets[i] = 0;
            }
            StartCoroutine(ApperDisappearCo(images, images.Length, delay, targets, parent));
        }

        private IEnumerator ApperDisappearCo(Image[] images, int count, float delay, int[] targets, GameObject parent = null)
        {
            _isRunning = true;
            if (targets[0] != 0)
            {
                if(parent != null)
                {
                    parent.SetActive(true);
                }
            }

            float curTime = 0;
            Color32[] colors = new Color32[count];

            for(int i = 0; i < count; i++)
            {
                colors[i] = images[i].color;
            }

            while(curTime < delay)
            {
                curTime += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(curTime / delay);
                for(int i = 0; i < count; i++)
                {
                    images[i].color = Color32.Lerp(colors[i], new Color32(colors[i].r, colors[i].g, colors[i].b, (byte)targets[i]), t);
                }
                yield return null;
            }

            for(int i = 0; i < count; i++)
            {
                images[i].color = new Color32(colors[i].r, colors[i].g, colors[i].b, (byte)targets[i]);
            }

            if(targets[0] == 0)
            {
                if (parent != null)
                {
                    parent.SetActive(false);
                    Time.timeScale = 1;
                }
            }

            _isRunning = false;
        }

        public GameObject[,] AddUI(ObjectPoolType type, Transform parent, int x, int y)
        {
            GameObject[,] uis = new GameObject[x,y];
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    GameObject slotObj = ObjectPoolManager.Instance.GetObject(type, parent);
                    uis[i,j] = slotObj;
                    // 이 부분이 배치하는 부분인데.....
                    slotObj.GetComponent<RectTransform>().localPosition = new Vector3(120 * i, 120 * -j, 0);
                }
            }

            return uis;
        }

        public void RemoveUI(ObjectPoolType type, Transform parent)
        {
            for(int i = parent.childCount - 1; i >= 0 ; i--)
            {
                ObjectPoolManager.Instance.ReturnObject(type, parent.GetChild(i).gameObject);
            }
        }
    }
}

