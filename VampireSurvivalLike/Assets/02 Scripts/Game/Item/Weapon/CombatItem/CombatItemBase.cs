using Item;
using Manager;
using MyInterface;
using MySO;
using MyStat;
using UnityEngine;

namespace CombatItem
{
    public class CombatItemBase : ItemBase
    {
        private ItemSO _combatItemSO;

        private ItemStat _stat;

        private IItemAttackStrategy _attackStrategy;

        private IEffect _effect;

        protected bool _isMaked = true;

        protected override void Awake()
        {
            base.Awake();
        }

        protected virtual void OnEnable()
        {
            Attack();

            StatManager.Instance.AddItemStat(gameObject.name, _stat);
        }

        protected virtual void OnDisable()
        {
            if(StatManager.Instance.FindItemStat(gameObject.name))
            {
                StatManager.Instance.RemoveItemStat(gameObject.name);
            }
        }

        protected void Init(ItemSO so, IItemAttackStrategy strategy, IEffect effect)
        {
            _combatItemSO = so;
            _stat = StatManager.Instance.SetStat(so);
            _attackStrategy = strategy;
            _effect = effect;
        }

        public void SetEffect(IEffect effect)
        {
            _effect = effect;
        }

        private void Attack()
        {
            if (_attackStrategy != null)
            {
                _attackStrategy.Attack(_combatItemSO, _effect);
            }
        }
    }
}

