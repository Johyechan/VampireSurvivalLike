using AttackStrategy;
using EffectDecorator;
using Manager;
using MyInterface;
using MySO;
using UnityEngine;

namespace CombatItem
{
    public class Sword : CombatItemBase
    {
        private IItemAttackStrategy _attackStrategy;

        private IEffect _effect;

        protected void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, so.range);
        }

        protected override void Awake()
        {
            base.Awake();

            _attackStrategy = GetComponent<MeleeAttack>();

            _effect = new NoneEffect();
        }

        protected override void OnEnable()
        {
            if (_isMaked)
            {
                _isMaked = false;
                return;
            }

            Init(so, _attackStrategy, _effect);

            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }
    }
}

