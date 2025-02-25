using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : AttackBase, IAttackStrategy
{
    private ItemBase _item;

    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(FireCo(_item));
    }

    public void Attack(ItemBase item)
    {
        _item = item;
        // 원거리 공격
        StartCoroutine(FireCo(item));
    }

    private IEnumerator FireCo(ItemBase item)
    {
        while (true) // 플레이어가 죽기 전까지
        {
            if(CheckEnemyInArea(item.so.range))
            {
                Fire(item.so);
                item.ApplyEffect();
                Debug.Log(1 / GameManager.Instance.AttackSpeedCalculate(1.0f,
                    StatManager.Instance.ItemTotalStat().attackSpeed + StatManager.Instance.PlayerStat.attackSpeed));
                yield return new WaitForSeconds(1 / GameManager.Instance.AttackSpeedCalculate(1.0f,
                    StatManager.Instance.ItemTotalStat().attackSpeed + StatManager.Instance.PlayerStat.attackSpeed)); // 공속
            }
            else
            {
                yield return null;
            }
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
            case RoleType.Rouge:
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
