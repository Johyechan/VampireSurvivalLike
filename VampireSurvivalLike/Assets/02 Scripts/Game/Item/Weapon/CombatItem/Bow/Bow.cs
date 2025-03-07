using AttackStrategy;
using EffectDecorator;
using MyInterface;
using MySO;
using UnityEngine;

namespace CombatItem
{
    public class Bow : CombatItemBase
    {
        private IItemAttackStrategy _strategy;

        private IEffect _effect;

        protected override void Awake()
        {
            base.Awake();

            _strategy = GetComponent<RangedAttack>();

            _effect = new NoneEffect();
            _effect = new AttackSpeedIncreaseDecorator(_effect, 1.0f);

            Init(so, _strategy, _effect);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }
    }
}

