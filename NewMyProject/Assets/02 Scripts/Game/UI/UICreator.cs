using Manager.Inventory;
using MyUI.Interface;
using MyUI.Slot;
using MyUtil.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace MyUI
{
    public class UICreator : MonoBehaviour
    {
        private IUILayoutStrategy _layoutStrategy;
        private IUISpawnStrategy _spawnStrategy;

        public void Init(IUILayoutStrategy layoutStrategy, IUISpawnStrategy spawnStrategy)
        {
            _layoutStrategy = layoutStrategy;
            _spawnStrategy = spawnStrategy;
        }

        // x = ���� ���� y = ���� ���� width = ���� ��ü�� �ʺ�, height = ���� ��ü�� ����, spacing = ����
        public void CreateUI(List<ObjectPoolType> types, Transform parentTrans, int x, int y, float width, float height, float spacing, int[,] backpackArr = null)
        {
            // rectTransform�� ������
            RectTransform rectTrans = parentTrans.GetComponent<RectTransform>();

            Vector2 firstPosVec = _layoutStrategy.GetPosition(rectTrans, x, y, width, height, spacing);

            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    if(backpackArr != null)
                    {
                        if (backpackArr[i, j] == 0)
                        {
                            continue;
                        }
                    }

                    ObjectPoolType type = GetRandomType(types);
                    GameObject obj = _spawnStrategy.SpawnUI(type, parentTrans);
                    float posX = firstPosVec.x + i * (width + spacing);
                    float posY = firstPosVec.y - j * (height + spacing);

                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);

                    if(type == ObjectPoolType.Slot)
                    {
                        InventoryManager.Instance.Grid[i, j] = obj.GetComponent<InventorySlot>();
                    }
                }
            }
        }

        private ObjectPoolType GetRandomType(List<ObjectPoolType> types)
        {
            return types[Random.Range(0, types.Count)];
        }
    }
}
