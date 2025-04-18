using Enemy;
using Item.Stat;
using Manager;
using UnityEngine;

namespace Item.Effect.OneItem
{
    public class AttackSpeedIncreaseEffect : IItemEffect
    {
        private IItemEffect _effect;

        private float _increaseValue = 0;

        public AttackSpeedIncreaseEffect(IItemEffect effect)
        {
            _effect = effect;
        }

        public void Effect(EnemyBase enemy = null)
        {
            _effect.Effect();
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

        public void RemoveEffect()
        {
            // 전체적으로 공속이 적용 됐을 때
            //ItemStat stat = StatManager.Instance.AllStat;
            //stat.attackSpeed -= _increaseValue;
            //StatManager.Instance.AllStat = stat;

            _increaseValue = 0;
        }
    }
}

