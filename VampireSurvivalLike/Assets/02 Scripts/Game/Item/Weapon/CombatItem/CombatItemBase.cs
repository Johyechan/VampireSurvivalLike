using Item;
using MyInterface;
using MySO;

namespace CombatItem
{
    public class CombatItemBase : ItemBase
    {
        private ItemSO _so;
        private IItemAttackStrategy _attackStrategy;
        private IEffect _effect;

        protected override void Awake()
        {
            base.Awake();
        }

        protected virtual void OnEnable()
        {
            // 스탯 관리 리스트에 스탯 추가
        }

        protected virtual void OnDisable()
        {
            // 스탯 관리 리스트에서 스탯 제거 
        }

        protected void Init(ItemSO so, IItemAttackStrategy strategy, IEffect effect)
        {
            _so = so;
            _attackStrategy = strategy;
            _effect = effect;
        }

        protected void Attack()
        {
            if (_attackStrategy != null)
            {
                _attackStrategy.Attack(_so, _effect);
            }
        }
    }
}

