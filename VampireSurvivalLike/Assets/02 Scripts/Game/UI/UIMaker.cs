using Inventory;
using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyUI
{
    public class UIMaker : MonoBehaviour
    {
        public GameObject[,] AddUI(ObjectPoolType type, Transform parent, int x, int y, int width, int height, float spacing, int[,] backpackArr = null)
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

            // 슬롯의 anchoredPosition이 중앙이기 때문에 실질적으로 확인할 때는 맨끝의 반반이 빠지기 때문에 총 하나가 빠진 것과 같다 그렇기에 실제로 슬롯이 x개 있어도 x - 1개로 위치 계산을 해야한다 이거지 세로도 똑같고
            float totalWidth = (x - 1) * width + (x - 1) * spacing;
            float totalHeight = (y - 1) * height + (y - 1) * spacing;

            // 중앙 배치를 위한 오프셋 계산
            float offsetX = (panelWidth - totalWidth) / 2;
            float offsetY = (panelHeight - totalHeight) / 2;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    GameObject obj = ObjectPoolManager.Instance.GetObject(type, parent);
                    obj.name += GameManager.Instance.itemNum++;
                    UIController controller = obj.GetComponent<UIController>();
                    if(obj.transform.childCount > 0)
                    {
                        GameObject childObj = obj.transform.GetChild(0).gameObject;
                        childObj.name += GameManager.Instance.itemNum;
                        TMP_Text tmpText = childObj.GetComponent<TMP_Text>();
                        ShopItem shopItem = obj.GetComponent<ShopItem>();
                        tmpText.text = shopItem.copySO.price + "$";
                    }
                    if (backpackArr != null)
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
                                controller.alphaValue = 0;
                            }
                        }
                    }
                    float posX = leftPositionX + offsetX + i * (width + spacing);
                    float posY = topPositionY - offsetY - j * (height + spacing);

                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
                    uis[i, j] = obj;
                }
            }

            return uis;
        }

        public void RemoveUI(ObjectPoolType type, Transform parent)
        {
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                ObjectPoolManager.Instance.ReturnObject(type, parent.GetChild(i).gameObject);
            }
        }
    }
}

