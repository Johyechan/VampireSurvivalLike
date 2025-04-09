using UnityEngine;

namespace Enemy.Interface
{
    // 움직임을 (플레이어를 따라다니기만 하는 움직임, 패트롤 움직임) 나누기 위한 인터페이스
    public interface IEnemyMoveStrategy
    {
        // 범위에 플레이어가 있는지 체크하는 함수
        public bool CheckArea();

        // 움직이는 함수
        public void Move();
    }
}

