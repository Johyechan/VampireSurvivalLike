using UnityEngine;

namespace Enemy.Interface
{
    // 공격 방식이 여러 방식으로 나뉠 수 있다고 생각하여
    // 확장성을 늘리기 위해 전략 패턴을 선택
    // 그래서 이 인터페이스를 구현하는 클래스를 만들어 여러 형태의 공격 방식을 필요에 따라 추가할 예정
    public interface IEnemyAttackStrategy
    {
        public bool CheckArea();

        public void Attack();
    }
}

