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

        // 생성자에서 변수 초기화
        public EnemyReSpawn(Transform enemyTrans, float distance)
        {
            _enemyTrans = enemyTrans;
            _distance = distance;
        }

        //public bool ReSpawnCheck()
        //{

        //}

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
