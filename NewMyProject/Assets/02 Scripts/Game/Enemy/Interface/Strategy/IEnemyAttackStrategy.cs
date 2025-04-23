using UnityEngine;

namespace Enemy.Interface.Strategy
{
    // 적의 공격 전략을 정의하는 인터페이스
    // 다양한 적의 공격 방식을 유연하게 확장할 수 있도록 한다
    public interface IEnemyAttackStrategy
    {
        // 공격 가능한 범위 내에 대상이 있는지 확인하는 함수
        // 공격 가능한 대상이 존재하면 true, 아니면 false
        public bool CheckArea();

        // 적의 공격을 실행하는 함수
        // 구현체에 따라 근접, 원거리 등 다양한 방식으로 동작할 수 있음
        public void Attack();
    }
}

