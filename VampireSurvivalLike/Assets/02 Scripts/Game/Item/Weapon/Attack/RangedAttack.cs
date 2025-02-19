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
            if(CheckEnemyInArea(item.So.Range))
            {
                Fire(item.So.FireObj, item.So.Range, item.So.FireSpeed);
                yield return new WaitForSeconds(0.5f); // ����
            }
            yield return null;
        }
    }

    private void Fire(ObjectPoolType type, float radius, float fireSpeed)
    {
        // Hitter ����
        GameObject bullet = ObjectPoolManager.Instance.GetObject(type);
        bullet.transform.position = transform.position;
        // ����� �� ã��
        GameObject enemy = FindCloseEnemyInArea(radius);
        // ����� ���� ���ϴ� ���� ã��
        Vector2 dir = (enemy.transform.position - bullet.transform.position).normalized;
        // �ѱ�, �Ѿ� ������
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = rotate;
        bullet.transform.rotation = transform.rotation;
        // Hitter ã�� �������� �߻�ӵ� ��ŭ ������
        Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();
        rigid2D.velocity = bullet.transform.up * fireSpeed;
    }
}
