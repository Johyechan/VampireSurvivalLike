using MyUI.Interface;
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
        public void CreateUI(List<ObjectPoolType> types, Transform parentTrans, int x, int y, int width, int height, float spacing, int[,] backpackArr = null)
        {
            // rectTransform�� ������
            RectTransform rectTrans = parentTrans.GetComponent<RectTransform>();

            Vector2 firstPosVec = _layoutStrategy.GetPosition(rectTrans, x, y, width, height, spacing);

            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    ObjectPoolType type = GetRandomType(types);
                    GameObject obj = _spawnStrategy.SpawnUI(type, parentTrans);
                    float posX = firstPosVec.x + i * (width + spacing);
                    float posY = firstPosVec.y - j * (height + spacing);

                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
                }
            }
        }

        private ObjectPoolType GetRandomType(List<ObjectPoolType> types)
        {
            return types[Random.Range(0, types.Count)];
        }
    }
}
