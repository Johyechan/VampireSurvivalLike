using Inventory;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUI
{
    public class UIMaker : MonoBehaviour
    {
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

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    GameObject obj = ObjectPoolManager.Instance.GetObject(type, parent);
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
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                ObjectPoolManager.Instance.ReturnObject(type, parent.GetChild(i).gameObject);
            }
        }
    }
}
