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
            // ��ü������ ������ �ø� ��
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
            // ��ü������ ������ ���� ���� ��
            //ItemStat stat = StatManager.Instance.AllStat;
            //stat.attackSpeed -= _increaseValue;
            //StatManager.Instance.AllStat = stat;

            _increaseValue = 0;
        }
    }
}

