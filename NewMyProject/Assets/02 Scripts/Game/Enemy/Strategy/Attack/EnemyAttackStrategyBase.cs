using Enemy.Interface;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    public abstract class EnemyAttackStrategyBase : IEnemyAttackStrategy
    {
        protected IDamageable _damageable;

        public abstract void Attack();

        public abstract bool CheckArea(Transform trans, float range, string layerMask);
    }
}

