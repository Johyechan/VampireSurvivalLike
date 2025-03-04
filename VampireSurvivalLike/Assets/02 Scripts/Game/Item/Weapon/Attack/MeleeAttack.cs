using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class MeleeAttack : AttackBase, IAttackStrategy
{
    private ItemBase _item;

    private Quaternion targetQuaternion;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _item.so.range);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        // 게임 종료가 아닐 경우에만 실행
        StopCoroutine(AttackCo(_item));
        StopCoroutine(AttackAnimationCo(_item));
        StopCoroutine(RotationAnimation(Quaternion.identity, targetQuaternion, 0.2f));
    }

    public void Attack(ItemBase item)
    {
        _item = item;
        // 근접 공격
        StartCoroutine(AttackCo(item));
    }

    private IEnumerator AttackCo(ItemBase item)
    {
        while(!GameManager.Instance.playerDead) // 플레이어 죽기 전까지
        {
            if (CheckEnemyInArea(item.so.range))
            {
                StartCoroutine(AttackAnimationCo(item));
                yield return new WaitForSeconds(GameManager.Instance.GetAttackSpeed());
            }
            yield return null;
        }
    }

    private IEnumerator AttackAnimationCo(ItemBase item)
    {
        GameObject enemy = FindCloseEnemyInArea(item.so.range);

        Vector2 dir = enemy.transform.position - transform.position;

        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;


        if (Mathf.Abs(angle) < 90)
        {
            if (Vector2.Dot(Vector2.right, dir) < 0)
            {
                targetQuaternion = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                targetQuaternion = Quaternion.Euler(0, 0, -90);
            }
        }
        else
        {
            targetQuaternion = Quaternion.Euler(0, 0, angle);
        }

        StartCoroutine(RotationAnimation(Quaternion.identity, targetQuaternion, GameManager.Instance.GetAttackSpeed() / 2));

        yield return new WaitForSeconds(GameManager.Instance.GetAttackSpeed() / 2);

        IDamageable damageable = enemy.GetComponent<IDamageable>();
        damageable.TakeDamage(StatManager.Instance.PlayerStat.damage + StatManager.Instance.ItemTotalStat().attackDamage);
        item.ApplyEffect();

        StartCoroutine(RotationAnimation(targetQuaternion, Quaternion.identity, GameManager.Instance.GetAttackSpeed() / 2));
    }

    private IEnumerator RotationAnimation(Quaternion currentQuaternion, Quaternion targetQuaternion, float delay)
    {
        float currentTime = 0;
        while (currentTime < delay)
        {
            float t = Mathf.Clamp01(currentTime / delay);
            transform.rotation = Quaternion.Lerp(currentQuaternion, targetQuaternion, t);
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetQuaternion;
    }
}
