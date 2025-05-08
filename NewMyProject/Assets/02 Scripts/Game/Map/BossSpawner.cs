using Enemy.Boss;
using Manager;
using UnityEngine;

namespace Map
{
    public class BossSpawner : MonoBehaviour
    {
        [SerializeField] private BossBase _stageBoss;

        private bool _once;

        private void Awake()
        {
            _once = false;
        }

        private void Update()
        {
            if(StageManager.Instance.StageEnd && !_once)
            {
                // 보스 생성
                _once = true;
            }
        }
    }
}

