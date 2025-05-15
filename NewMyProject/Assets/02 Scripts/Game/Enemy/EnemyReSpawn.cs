using Manager;
using UnityEngine;

namespace Enemy
{
    // 작성자: 조혜찬
    // 적이 스폰 이후 플레이어와 너무 떨어졌을 때 플레이어 이동 방향으로 재스폰하는 기능을 담당하는 클래스
    public class EnemyReSpawn
    {
        private Transform _enemyTrans; // 적 Transform
        private float _distance; // 플레이어로부터 얼마나 떨어질지
        private float _needReSpawnDistance;

        // 생성자에서 변수 초기화
        public EnemyReSpawn(Transform enemyTrans, float distance, float needReSpawnDistance)
        {
            _enemyTrans = enemyTrans;
            _distance = distance;
            _needReSpawnDistance = needReSpawnDistance;
        }

        // 재스폰 해야 하는 상황인지 판단하는 함수
        public bool ReSpawnCheck()
        {
            float distance = Vector2.Distance(GameManager.Instance.player.transform.position, _enemyTrans.position); // 플레이어와 적 사이 거리
            Debug.Log(distance);

            if(distance >= _needReSpawnDistance) // 만약 떨어진 거리가 재스폰 해야하는 거리 이상이라면
            {
                if(GameManager.Instance.PlayerMoveDir != Vector2.zero) // 그리고 플레이어가 움직이고 있다면
                {
                    return true; // 재스폰 해라
                }
            }

            return false; // 재스폰 하지 마
        }

        // 재스폰 하는 함수
        public void ReSpawn()
        {
            Vector2 moveDir = GameManager.Instance.PlayerMoveDir.normalized; // 플레이어가 이동하는 방향
            float angle = Random.Range(-30f, 30f); // 랜덤하게 회전시킬 값
            Quaternion rotation = Quaternion.Euler(0, 0, angle); // 랜덤한 회전 값
            Vector2 spawDir = rotation * moveDir; // 플레이어가 움직이는 방향에서 -30도 ~ 30도 사이의 랜덤한 각도에 위치한 생성 지점
            Vector2 reSpawnPos = (Vector2)GameManager.Instance.player.transform.position + spawDir * _distance; // 플레이어 위치에서부터 _distance만큼 떨어진 생성 지점

            _enemyTrans.position = reSpawnPos; // 적을 생성 지점으로 옮김
        }
    }
}
// 마지막 작성 일자: 2025.05.15
