using Inventory;
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

            for(int i = 0; i < count; i++)
            {
                if (colors[i] != Color.magenta && targets[i] != -1)
                {
                    images[i].color = new Color32(colors[i].r, colors[i].g, colors[i].b, (byte)targets[i]);
                }
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

        public GameObject[,] AddUI(ObjectPoolType type, Transform parent, int x, int y, int[,] backpackArr = null)
        {
            GameObject[,] uis = new GameObject[x, y];

            RectTransform panelRect = parent.GetComponent<RectTransform>();
            float panelWidth = panelRect.rect.width;
            float panelHeight = panelRect.rect.height;

            // 부모 패널의 anchoredPosition (중심 기준)
            float panelPosX = panelRect.anchoredPosition.x;
            float panelPosY = panelRect.anchoredPosition.y;

            // pivot.x가 0.5일 경우, 부모 패널의 중앙이 기준이다. 0이면 왼쪽, 1이면 오른쪽이 기준.
            float pivotX = panelRect.pivot.x;
            float pivotY = panelRect.pivot.y;

            // 패널의 맨 왼쪽 위치를 계산 (x좌표)
            float leftPositionX = panelPosX - panelWidth * pivotX;
            float topPositionY = panelPosY + panelHeight * pivotY;

            float slotWidth = 100f; 
            float slotHeight = 100f; 
            float slotSpacing = 10f; 

            // 슬롯의 anchoredPosition이 중앙이기 때문에 실질적으로 확인할 때는 맨끝의 반반이 빠지기 때문에 총 하나가 빠진 것과 같다 그렇기에 실제로 슬롯이 x개 있어도 x - 1개로 위치 계산을 해야한다 이거지 세로도 똑같고
            float totalWidth = (x - 1) * slotWidth + (x - 1) * slotSpacing;
            float totalHeight = (y - 1) * slotHeight + (y - 1) * slotSpacing;

            // 중앙 배치를 위한 오프셋 계산
            float offsetX = (panelWidth - totalWidth) / 2;
            float offsetY = (panelHeight - totalHeight) / 2;

            if(type == ObjectPoolType.Slot)
            {
                Debug.Log(leftPositionX);
                Debug.Log(offsetX);
            }

            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    GameObject obj = ObjectPoolManager.Instance.GetObject(type, parent);
                    if(backpackArr != null)
                    {
                        if (type == ObjectPoolType.Slot)
                        {
                            InventorySlot slot = obj.GetComponent<InventorySlot>();
                            if (backpackArr[i, j] == 1)
                            {
                                slot.IsUsing = true;
                            }
                            else
                            {
                                slot.IsUsing = false;
                            }
                            float posX = leftPositionX + offsetX + i * (slotWidth + slotSpacing);
                            float posY = topPositionY - offsetY - j * (slotHeight + slotSpacing);

                            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
                        }
                    }

                    uis[i, j] = obj;
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

