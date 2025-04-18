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

        public void ResetAttackSpeed()
        {
            // ��ü������ ������ ���� ���� ��
            //ItemStat stat = StatManager.Instance.AllStat;
            //stat.attackSpeed -= _increaseValue;
            //StatManager.Instance.AllStat = stat;

            _increaseValue = 0;
        }
    }
}

