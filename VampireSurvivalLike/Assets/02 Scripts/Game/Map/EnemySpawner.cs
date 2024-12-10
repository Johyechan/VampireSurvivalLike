using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.Pool;
using Cinemachine.Editor;

namespace Map
{
    public class EnemySpawner : BaseMap
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Transform _spawnParent;
        
        [SerializeField] private float _spawnCoolTime;

        protected override void Start()
        {
            base.Start();
            StartCoroutine(SpawnEnemyCo());
        }

        protected override void Update()
        {
            base.Update();
            if(GameManager.Instance.groundMove)
            {

            }
        }

        private IEnumerator SpawnEnemyCo()
        {
            while (true)
            {
                SpawnAtEdge();
                yield return new WaitForSeconds(_spawnCoolTime);
            }
        }

        private void SpawnAtEdge()
        {
            // 랜덤한 카메라 외곽 좌표 선택
            Vector2 spawnViewportPosition = GetRandomEdgePosition();

            // 뷰포트 좌표를 월드 좌표로 변환
            Vector3 spawnWorldPosition = mainCamera.ViewportToWorldPoint(new Vector3(spawnViewportPosition.x, spawnViewportPosition.y, mainCamera.nearClipPlane));

            // 스폰 위치 보정: z 값 조정 필요
            spawnWorldPosition.z = 0;

            GameObject enemy = ObjectPoolManager.Instance.GetObject(ObjectPoolType.NormalEnemy, _spawnParent);
            enemy.transform.position = spawnWorldPosition;
        }

        private Vector2 GetRandomEdgePosition()
        {
            // 카메라 외곽 중 랜덤한 방향 선택
            int edge = Random.Range(0, 4); // 0: 좌, 1: 우, 2: 상, 3: 하

            switch (edge)
            {
                case 0: return new Vector2(-0.1f, Random.Range(0f, 1f)); // 왼쪽
                case 1: return new Vector2(1.1f, Random.Range(0f, 1f));  // 오른쪽
                case 2: return new Vector2(Random.Range(0f, 1f), 1.1f);  // 위쪽
                case 3: return new Vector2(Random.Range(0f, 1f), -0.1f); // 아래쪽
                default: return Vector2.zero;
            }
        }
    }
}

