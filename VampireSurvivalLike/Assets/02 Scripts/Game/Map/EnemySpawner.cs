using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.Pool;

namespace Map
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Transform _spawnParent;
        
        [SerializeField] private float _spawnCoolTime;

        private void Start()
        {
            StartCoroutine(SpawnEnemyCo());
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
            // ������ ī�޶� �ܰ� ��ǥ ����
            Vector2 spawnViewportPosition = GetRandomEdgePosition();

            // ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ
            Vector3 spawnWorldPosition = mainCamera.ViewportToWorldPoint(new Vector3(spawnViewportPosition.x, spawnViewportPosition.y, mainCamera.nearClipPlane));

            // ���� ��ġ ����: z �� ���� �ʿ�
            spawnWorldPosition.z = 0;

            GameObject enemy = ObjectPoolManager.Instance.GetObject(ObjectPoolType.NormalEnemy, _spawnParent);
            enemy.transform.position = spawnWorldPosition;
        }

        private Vector2 GetRandomEdgePosition()
        {
            // ī�޶� �ܰ� �� ������ ���� ����
            int edge = Random.Range(0, 4); // 0: ��, 1: ��, 2: ��, 3: ��

            // Ȯ�� ������ �ʿ��� �׷��� �÷��̾ ���� �ִ� �������� ������ �ϱ�
            if (Input.GetKey(KeyCode.W))
            {
                int rand = Random.Range(0, 5);
                if(rand < 4)
                {
                    edge = 2;
                }
            }
            if(Input.GetKey(KeyCode.A))
            {
                int rand = Random.Range(0, 5);
                if (rand < 4)
                {
                    edge = 0;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                int rand = Random.Range(0, 5);
                if (rand < 4)
                {
                    edge = 3;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                int rand = Random.Range(0, 5);
                if (rand < 4)
                {
                    edge = 1;
                }
            }

            switch (edge)
            {
                case 0: return new Vector2(-0.1f, Random.Range(0f, 1f)); // ����
                case 1: return new Vector2(1.1f, Random.Range(0f, 1f));  // ������
                case 2: return new Vector2(Random.Range(0f, 1f), 1.1f);  // ����
                case 3: return new Vector2(Random.Range(0f, 1f), -0.1f); // �Ʒ���
                default: return Vector2.zero;
            }
        }
    }
}

