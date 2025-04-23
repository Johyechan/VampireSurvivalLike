using UnityEngine;

namespace Enemy.Interface.Strategy
{
    // 적의 이동 전략을 정의하는 인터페이스
    // 다양한 이동 방식을 유연하게 확장할 수 있도록 한다
    public interface IEnemyMoveStrategy
    {
        // 적이 범위 안에 들어왔는지 확인하는 함수
        public bool CheckArea();

        // 적의 이동을 수행하는 함수
        // 구현체에 따라 따라가기, 순찰하기 등 다양한 방식으로 동작할 수 있음
        public void Move();
    }
}

