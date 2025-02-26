using Pool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowAttack : AttackBase, IAttackStrategy
{
    public void Attack(ItemBase item)
    {
        // ������ ����
        StartCoroutine(ThrowCo(item));
    }

    private IEnumerator ThrowCo(ItemBase item)
    {
        while(true) // �÷��̾ �ױ� ������
        {
            if (CheckEnemyInArea(item.so.range))
            {
                Fire(item.so);
                yield return null; // ����
            }
            yield return null;
        }
    }

    private void Fire(ItemSO so)
    {
        // Hitter ����
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
        // ����� �� ã��
        GameObject enemy = FindCloseEnemyInArea(so.range);
        // ����� ���� ���ϴ� ���� ã��
        Vector2 dir = (enemy.transform.position - projectileObj.transform.position).normalized;
        // �ѱ�, �Ѿ� ������
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = rotate;
        projectileObj.transform.rotation = transform.rotation;
        // Hitter ã�� �������� �߻�ӵ� ��ŭ ������
        Rigidbody2D rigid2D = projectileObj.GetComponent<Rigidbody2D>();
        rigid2D.velocity = projectileObj.transform.up * so.fireSpeed;
    }
}
