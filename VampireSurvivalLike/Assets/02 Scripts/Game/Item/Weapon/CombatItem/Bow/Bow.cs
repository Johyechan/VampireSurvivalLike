using AttackStrategy;
using EffectDecorator;
using MyInterface;
using MySO;
using NPOI.OpenXmlFormats.Vml.Office;
using UnityEngine;

namespace CombatItem
{
    public class Bow : CombatItemBase
    {
        private IItemAttackStrategy _strategy;

        private IEffect _effect;

        protected void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, so.range);
        }

        protected override void Awake()
        {
            base.Awake();

            _strategy = GetComponent<RangedAttack>();

            _effect = new NoneEffect();
            _effect = new AttackSpeedIncreaseDecorator(_effect, 1.0f);
        }

        protected override void OnEnable()
        {
            if (_isMaked)
            {
                _isMaked = false;
                return;
            }

            Init(so, _strategy, _effect);

            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }
    }
}

