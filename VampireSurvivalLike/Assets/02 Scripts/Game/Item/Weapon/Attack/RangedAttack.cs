using CombatItem;
using Manager;
using MyEnum;
using MyInterface;
using MySO;
using Pool;
using System.Collections;
using UnityEngine;

namespace AttackStrategy
{
    public class RangedAttack : AttackBase
    {
        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public override void Attack(ItemSO so, IEffect effect)
        {
            StartCoroutine(AttackCo(so, effect));
        }

        private IEnumerator AttackCo(ItemSO so, IEffect effect)
        {
            while (!GameManager.Instance.playerDead) // 플레이어가 죽기 전까지
            {
                if (CheckEnemyInArea(so.range))
                {
                    Fire(so);

                    if (effect != null)
                        effect.ApplyEffect();

                    yield return new WaitForSeconds(GameManager.Instance.GetAttackSpeed());
                }
                yield return null;
            }
        }

        private void Fire(ItemSO so)
        {
            // Hitter 생성
            GameObject projectileObj = ObjectPoolManager.Instance.GetObject(so.fireObjType);

            Projectile projectile = projectileObj.GetComponent<Projectile>();
            switch (so.role)
            {
                case RoleType.Knight:
                case RoleType.Archer:
                case RoleType.Rogue:
                    {
                        projectile.Init(so.fireObjType, StatManager.Instance.TotalItemStat.attackDamage + StatManager.Instance.PlayerStat.damage);
                    }
                    break;
                case RoleType.Magician:
                    {
                        projectile.Init(so.fireObjType, StatManager.Instance.TotalItemStat.abilityPower + StatManager.Instance.PlayerStat.damage);
                    }
                    break;
                case RoleType.Reaper:
                    {
                        projectile.Init(so.fireObjType, StatManager.Instance.TotalItemStat.soulPower + StatManager.Instance.PlayerStat.damage);
                    }
                    break;
            }
            projectile.DeathCoolStart();

            projectileObj.transform.position = transform.position;
            projectileObj.transform.rotation = transform.rotation;
            Rigidbody2D rigid2D = projectileObj.GetComponent<Rigidbody2D>();
            rigid2D.velocity = projectileObj.transform.up * so.fireSpeed;
        }
    }
}

