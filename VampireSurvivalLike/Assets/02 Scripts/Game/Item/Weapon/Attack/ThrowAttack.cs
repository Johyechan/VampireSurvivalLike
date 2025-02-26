using Pool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowAttack : AttackBase, IAttackStrategy
{
    public void Attack(ItemBase item)
    {
        // 던지기 공격
        StartCoroutine(ThrowCo(item));
    }

    private IEnumerator ThrowCo(ItemBase item)
    {
        while(true) // 플레이어가 죽기 전까지
        {
            if (CheckEnemyInArea(item.so.range))
            {
                Fire(item.so);
                yield return null; // 공속
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
        // 가까운 적 찾기
        GameObject enemy = FindCloseEnemyInArea(so.range);
        // 가까운 적을 향하는 방향 찾기
        Vector2 dir = (enemy.transform.position - projectileObj.transform.position).normalized;
        // 총구, 총알 돌리기
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = rotate;
        projectileObj.transform.rotation = transform.rotation;
        // Hitter 찾은 방향으로 발사속도 만큼 날리기
        Rigidbody2D rigid2D = projectileObj.GetComponent<Rigidbody2D>();
        rigid2D.velocity = projectileObj.transform.up * so.fireSpeed;
    }
}
