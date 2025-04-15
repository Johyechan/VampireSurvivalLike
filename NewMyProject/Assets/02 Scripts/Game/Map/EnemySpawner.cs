using Manager;
using MyUtil.Pool;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<ObjectPoolType> _enemyTypes = new List<ObjectPoolType>();

        public float SpawnDelayTime { get; set; }

        [SerializeField] private float _spawnRadius;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            if(GameManager.Instance != null)
                Gizmos.DrawWireSphere(GameManager.Instance.player.transform.position, _spawnRadius);
        }

        private void Awake()
        {
            SpawnDelayTime = 1f;
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnCo());
        }

        private void OnDisable()
        {
            StopCoroutine(SpawnCo());
        }

        private IEnumerator SpawnCo()
        {
            yield return new WaitForSeconds(SpawnDelayTime);

            while(!GameManager.Instance.gameOver)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(SpawnDelayTime);
            }
        }

        private void SpawnEnemy()
        {
            Vector2 dir = Random.insideUnitCircle.normalized;
            Vector2 spawnPos = (Vector2)GameManager.Instance.player.transform.position + dir * _spawnRadius;

            GameObject enemy = ObjectPoolManager.Instance.GetObject(RandomType());
            enemy.transform.position = spawnPos;
        }

        private ObjectPoolType RandomType()
        {
            int index = Random.Range(0, _enemyTypes.Count);
            return _enemyTypes[index];
        }
    }
}