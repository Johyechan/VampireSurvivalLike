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

        // x = 가로 개수 y = 세로 개수 width = 생성 객체의 너비, height = 생성 객체의 높이, spacing = 간격
        public void CreateUI(List<ObjectPoolType> types, Transform parentTrans, int x, int y, float width, float height, float spacing, int[,] backpackArr = null)
        {
            // rectTransform을 가져옴
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

                    if (backpackArr != null)
                    {
                        if (backpackArr[i, j] == 0)
                        {
                            obj.SetActive(false);
                        }
                    }

                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);

                    if(type == ObjectPoolType.Slot)
                    {
                        InventorySlot slot = obj.GetComponent<InventorySlot>();
                        slot.X = i;
                        slot.Y = j;
                        slot.IsEmpty = false;
                        InventoryManager.Instance.Grid[i, j] = slot;
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
