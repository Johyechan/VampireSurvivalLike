using Enemy;
using Item.Stat;
using Manager;
using UnityEngine;

namespace Item.Effect.OneItem
{
    public class AttackSpeedIncreaseEffect : IItemEffect
    {
        private float _increaseValue = 0;

        public void Effect(EnemyBase enemy = null)
        {
            // 전체적으로 공속을 올릴 때
            //ItemStat stat = StatManager.Instance.AllStat;
            //stat.attackSpeed++;
            //_increaseValue++;
            //StatManager.Instance.AllStat = stat;
            _increaseValue++;
        }

        public float ReturnAttackSpeed()
        {
            return _increaseValue;
        }

        public void ResetAttackSpeed()
        {
            // 전체적으로 공속이 적용 됐을 때
            //ItemStat stat = StatManager.Instance.AllStat;
            //stat.attackSpeed -= _increaseValue;
            //StatManager.Instance.AllStat = stat;

            _increaseValue = 0;
        }
    }
}

