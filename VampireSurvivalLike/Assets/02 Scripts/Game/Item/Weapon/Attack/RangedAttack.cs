using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : AttackBase, IAttackStrategy
{
    public void Attack(ItemBase item)
    {
        // ���Ÿ� ����
        StartCoroutine(FireCo(item));
    }

    private IEnumerator FireCo(ItemBase item)
    {
        while (true) // �÷��̾ �ױ� ������
        {
            if(CheckEnemyInArea(item.So.range))
            {
                Fire(item.So);
                yield return new WaitForSeconds(1 / GameManager.Instance.AttackSpeedCalculate(1.0f, item.So.attackSpeed)); // ����
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Fire(ItemSO so)
    {
        // Hitter ����
        GameObject projectileObj = ObjectPoolManager.Instance.GetObject(so.fireObjType);

        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectile.Init(so.fireObjType, so.attackDamage);
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
