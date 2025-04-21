using Item.Effect;
using Item.Strategy;
using Manager;
using MyUtil.Interface;
using Player.Enum;
using UnityEngine;

namespace Item.Weapon.Melee
{
    public class MeleeWeapon : WeaponItem
    {
        protected float _damage;

        protected IDamageable _damageable;

        private BoxCollider2D _collider2D;

        public bool IsAttackEnd { get; set; }

        protected virtual void Awake()
        {
            IsAttackEnd = true;

            _collider2D = GetComponent<BoxCollider2D>();

            _weaponStrategy = new MeleeWeaponStrategy(transform, itemSO.range, "Enemy", this);

            EffectContainer = new ItemEffectContainer();
        }

        protected virtual void Update()
        {
            if (IsAttackEnd)
            {
                LookCloseEnemy();
                _collider2D.enabled = false;
            }
            else
            {
                _collider2D.enabled = true;
            }
        }

        public void OnDamage()
        {
            switch (itemSO.role)
            {
                case RoleType.Reaper:
                    _damage = StatManager.Instance.AllStat.soulPower + StatManager.Instance.PlayerStat.damage;
                    break;
                case RoleType.Magician:
                    _damage = StatManager.Instance.AllStat.abilityPower + StatManager.Instance.PlayerStat.damage;
                    break;
                default:
                    _damage = StatManager.Instance.AllStat.attackDamage + StatManager.Instance.PlayerStat.damage;
                    break;
            }

            _damageable.TakeDamage(_damage);
        }
    }
}

