using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRangedAttack : NewAttackBase
{
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public override void Attack(ItemSO so, INewEffect effect)
    {
        base.Attack(so, effect);
        StartCoroutine(AttackCo(so, effect));
    }

    private IEnumerator AttackCo(ItemSO so, INewEffect effect)
    {
        while (!GameManager.Instance.playerDead) // 플레이어가 죽기 전까지
        {
            if (CheckEnemyInArea(so.range))
            {
                Fire(so);
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
                    projectile.Init(so.fireObjType, StatManager.Instance.ItemTotalStat().attackDamage + StatManager.Instance.PlayerStat.damage);
                }
                break;
            case RoleType.Magician:
                {
                    projectile.Init(so.fireObjType, StatManager.Instance.ItemTotalStat().abilityPower + StatManager.Instance.PlayerStat.damage);
                }
                break;
            case RoleType.Reaper:
                {
                    projectile.Init(so.fireObjType, StatManager.Instance.ItemTotalStat().soulPower + StatManager.Instance.PlayerStat.damage);
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
