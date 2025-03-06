using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMeleeAttack : NewAttackBase
{
    private Quaternion targetQuaternion;

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
        while (!GameManager.Instance.playerDead) // 플레이어 죽기 전까지
        {
            if (CheckEnemyInArea(so.range))
            {
                StartCoroutine(AttackAnimationCo(so, effect));
                yield return new WaitForSeconds(GameManager.Instance.GetAttackSpeed());
            }
            yield return null;
        }
    }

    private IEnumerator AttackAnimationCo(ItemSO so, INewEffect effect)
    {
        GameObject enemy = FindCloseEnemyInArea(so.range);

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
        effect.ApplyEffect();

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
