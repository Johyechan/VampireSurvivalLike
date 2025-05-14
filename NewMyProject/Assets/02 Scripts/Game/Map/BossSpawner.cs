using Enemy.Boss;
using Enemy.Boss.CutScene;
using Enemy.Boss.Interface;
using Manager;
using UnityEngine;

namespace Map
{
    public class BossSpawner : MonoBehaviour
    {
        [SerializeField] private CutSceneBase _bossCutScene;

        private bool _once;

        private void Awake()
        {
            _once = false;
        }

        private void Update()
        {
            if(StageManager.Instance.LastStageEnd && !_once)
            {
                // 보스 생성
                _bossCutScene.CutScenePlay();
                _once = true;
            }
        }
    }
}

