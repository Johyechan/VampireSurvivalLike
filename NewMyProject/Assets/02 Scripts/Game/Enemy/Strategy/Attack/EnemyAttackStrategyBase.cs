using Enemy.Interface;
using Enemy.Interface.Strategy;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    // 기본적으로 적 공격에 필요한 것들을 가지는 클래스
    public abstract class EnemyAttackStrategyBase : IEnemyAttackStrategy
    {
        // 구현할 인터페이스를 반드시 정의하도록 추상 메서드로 선언
        public abstract void Attack();

        public abstract bool CheckArea();
    }
}

