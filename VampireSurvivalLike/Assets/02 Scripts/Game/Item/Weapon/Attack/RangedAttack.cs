using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : AttackBase, IAttackStrategy
{
    private ItemBase _item;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _item.so.range);
    }

    protected override void Update()
    {
        base.Update();
        FollowEnemy(_item.so, 10);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(AttackCo(_item));
    }

    public void Attack(ItemBase item)
    {
        _item = item;
        // 원거리 공격
        StartCoroutine(AttackCo(item));
    }

    private IEnumerator AttackCo(ItemBase item)
    {
        while (true) // 플레이어가 죽기 전까지
        {
            if(CheckEnemyInArea(item.so.range))
            {
                Fire(item.so);
                item.ApplyEffect();
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
        switch(so.role)
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

        FollowEnemy(so);
        projectileObj.transform.position = transform.position;
        projectileObj.transform.rotation = transform.rotation;
        Rigidbody2D rigid2D = projectileObj.GetComponent<Rigidbody2D>();
        rigid2D.velocity = projectileObj.transform.up * so.fireSpeed;
    }
}
