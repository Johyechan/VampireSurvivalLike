using Manager;
using MyUtil.Pool;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    // �ۼ���: ������
    // �� ������ ����ϴ� Ŭ����
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<ObjectPoolType> _enemyTypes = new List<ObjectPoolType>(); // ������ ���� Ÿ���� ������ ����Ʈ

        [SerializeField] private float SpawnDelayTime; // ���� ����

        [SerializeField] private float _spawnRadius; // ���� ����

        private Coroutine _currentCo; // ���� ���� ���� �ڷ�ƾ

        // �����
        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.yellow;
            if(GameManager.Instance != null)
                Gizmos.DrawWireSphere(GameManager.Instance.player.transform.position, _spawnRadius);
        }

        // Ȱ��ȭ ���� �� ���� �ڷ�ƾ ����
        private void OnEnable()
        {
            _currentCo = StartCoroutine(SpawnCo());
        }

        // ��Ȱ��ȭ ���� �� ���� �ڷ�ƾ ����
        private void OnDisable()
        {
            StopCoroutine(_currentCo);
        }

        // ���� �ڷ�ƾ
        private IEnumerator SpawnCo()
        {
            yield return null; // �� ������ ���

            while (!GameManager.Instance.GameOver && !StageManager.Instance.LastStageEnd) // ���� ������ �ƴϰ� ������ ���������� ������ �ʾ��� ��
            {
                if (StageManager.Instance.StageEnd) // ���������� ����Ǿ��� ���� ��� ���� ����
                {
                    yield return null;
                    continue;
                }

                SpawnEnemy(); // ���� �Լ�
                yield return new WaitForSeconds(SpawnDelayTime); // ������
            }
        }

        // ���� ���� �Լ�
        private void SpawnEnemy()
        {
            Vector2 dir = Random.insideUnitCircle.normalized; // ������ �� �ѷ� ������ ������ ��ġ�� ����
            Vector2 spawnPos = (Vector2)GameManager.Instance.player.transform.position + dir * _spawnRadius; // �÷��̾� ��ġ�κ��� _spawnRadius��ŭ ������ �Ÿ��� ������ ��ġ

            GameObject enemy = ObjectPoolManager.Instance.GetObject(RandomType()); // ������ Ÿ���� �� ����
            enemy.transform.position = spawnPos; // �� ��ġ�� ������ ��ġ�� ����
        }

        // ������ �� Ÿ���� ��ȯ�ϴ� �Լ�
        private ObjectPoolType RandomType()
        {
            int index = Random.Range(0, _enemyTypes.Count); // ���� ���� �� Ÿ�� ����Ʈ���� ������ ���� ������
            return _enemyTypes[index]; // ������ �� Ÿ�� ��ȯ
        }
    }
}
// ������ �ۼ� ����: 2025.05.15