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

            // �θ� �г��� anchoredPosition (�߽� ����)
            float panelPosX = panelRect.anchoredPosition.x;
            float panelPosY = panelRect.anchoredPosition.y;

            // pivot.x�� 0.5�� ���, �θ� �г��� �߾��� �����̴�. 0�̸� ����, 1�̸� �������� ����.
            float pivotX = panelRect.pivot.x;
            float pivotY = panelRect.pivot.y;

            // �г��� �� ���� ��ġ�� ��� (x��ǥ)
            float leftPositionX = panelPosX - panelWidth * pivotX;
            float topPositionY = panelPosY + panelHeight * pivotY;

            float slotWidth = 100f; 
            float slotHeight = 100f; 
            float slotSpacing = 10f; 

            // ������ anchoredPosition�� �߾��̱� ������ ���������� Ȯ���� ���� �ǳ��� �ݹ��� ������ ������ �� �ϳ��� ���� �Ͱ� ���� �׷��⿡ ������ ������ x�� �־ x - 1���� ��ġ ����� �ؾ��Ѵ� �̰��� ���ε� �Ȱ���
            float totalWidth = (x - 1) * slotWidth + (x - 1) * slotSpacing;
            float totalHeight = (y - 1) * slotHeight + (y - 1) * slotSpacing;

            // �߾� ��ġ�� ���� ������ ���
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

