using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : AttackBase, IAttackStrategy
{
    public void Attack(ItemBase item)
    {
        // 원거리 공격
        StartCoroutine(FireCo(item));
    }

    private IEnumerator FireCo(ItemBase item)
    {
        while (true) // 플레이어가 죽기 전까지
        {
            if(CheckEnemyInArea(item.So.Range))
            {
                Fire(item.So.FireObj, item.So.Range, item.So.FireSpeed);
                yield return new WaitForSeconds(0.5f); // 공속
            }
            yield return null;
        }
    }

    private void Fire(ObjectPoolType type, float radius, float fireSpeed)
    {
        // Hitter 생성
        GameObject bullet = ObjectPoolManager.Instance.GetObject(type);
        bullet.transform.position = transform.position;
        // 가까운 적 찾기
        GameObject enemy = FindCloseEnemyInArea(radius);
        // 가까운 적을 향하는 방향 찾기
        Vector2 dir = (enemy.transform.position - bullet.transform.position).normalized;
        // 총구, 총알 돌리기
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = rotate;
        bullet.transform.rotation = transform.rotation;
        // Hitter 찾은 방향으로 발사속도 만큼 날리기
        Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();
        rigid2D.velocity = bullet.transform.up * fireSpeed;
    }
}
