using AttackStrategy;
using EffectDecorator;
using MyInterface;
using MySO;
using UnityEngine;

namespace CombatItem
{
    public class Sword : CombatItemBase
    {
        private IItemAttackStrategy _attackStrategy;

        private IEffect _effect;

        protected override void Awake()
        {
            base.Awake();

            _attackStrategy = GetComponent<MeleeAttack>();

            _effect = new NoneEffect();

            Init(so, _attackStrategy, _effect);
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

