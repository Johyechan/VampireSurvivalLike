using Manager;
using MyUtil.Pool;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    // 작성자: 조혜찬
    // 적 스폰을 담당하는 클래스
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<ObjectPoolType> _enemyTypes = new List<ObjectPoolType>(); // 스폰할 적의 타입을 가지는 리스트

        [SerializeField] private float SpawnDelayTime; // 스폰 간격

        [SerializeField] private float _spawnRadius; // 스폰 범위

        private Coroutine _currentCo; // 현재 실행 중인 코루틴

        // 디버그
        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.yellow;
            if(GameManager.Instance != null)
                Gizmos.DrawWireSphere(GameManager.Instance.player.transform.position, _spawnRadius);
        }

        // 활성화 됐을 때 스폰 코루틴 실행
        private void OnEnable()
        {
            _currentCo = StartCoroutine(SpawnCo());
        }

        // 비활성화 됐을 때 스폰 코루틴 정지
        private void OnDisable()
        {
            StopCoroutine(_currentCo);
        }

        // 스폰 코루틴
        private IEnumerator SpawnCo()
        {
            yield return null; // 한 프레임 대기

            while (!GameManager.Instance.GameOver && !StageManager.Instance.LastStageEnd) // 게임 오버가 아니고 마지막 스테이지가 끝나지 않았을 때
            {
                if (StageManager.Instance.StageEnd) // 스테이지가 종료되었을 때는 잠시 스폰 정지
                {
                    yield return null;
                    continue;
                }

                SpawnEnemy(); // 스폰 함수
                yield return new WaitForSeconds(SpawnDelayTime); // 딜레이
            }
        }

        // 실제 스폰 함수
        private void SpawnEnemy()
        {
            Vector2 dir = Random.insideUnitCircle.normalized; // 랜덤한 원 둘레 뱡향의 랜덤한 위치를 가짐
            Vector2 spawnPos = (Vector2)GameManager.Instance.player.transform.position + dir * _spawnRadius; // 플레이어 위치로부터 _spawnRadius만큼 떨어진 거리의 랜덤한 위치

            GameObject enemy = ObjectPoolManager.Instance.GetObject(RandomType()); // 랜덤한 타입의 적 생성
            enemy.transform.position = spawnPos; // 적 위치를 랜덤한 위치로 변경
        }

        // 랜덤한 적 타입을 반환하는 함수
        private ObjectPoolType RandomType()
        {
            int index = Random.Range(0, _enemyTypes.Count); // 현재 가진 적 타입 리스트에서 랜덤한 값을 가져옴
            return _enemyTypes[index]; // 랜덤한 적 타입 반환
        }
    }
}
// 마지막 작성 일자: 2025.05.15