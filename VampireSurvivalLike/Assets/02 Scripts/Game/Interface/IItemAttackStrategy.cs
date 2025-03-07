using MySO;

namespace MyInterface
{
    public interface IItemAttackStrategy
    {
        public void Attack(ItemSO so, IEffect effect);
    }
}

