using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MeleeAttack : AttackBase, IAttackStrategy
{
    private ItemBase _item;

    private Quaternion currentQuaternion;
    private Quaternion targetQuaternion;

    private float _rotateSpeed = 45f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _item.so.range);
    }

    protected override void Update()
    {
        base.Update();
        FollowEnemy(_item.so, _rotateSpeed);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(AttackCo(_item));
        //StopCoroutine(AttackAnimationCo(_item));
        StopCoroutine(RotationAnimation(currentQuaternion, targetQuaternion, 0.2f));
    }

    public void Attack(ItemBase item)
    {
        _item = item;
        // 근접 공격
        StartCoroutine(AttackCo(item));
    }

    private IEnumerator AttackCo(ItemBase item)
    {
        while(true) // 플레이어 죽기 전까지
        {
            if (CheckEnemyInArea(item.so.range))
            {
                //StartCoroutine(AttackAnimationCo(item));
                GameObject enemy = FindCloseEnemyInArea(item.so.range);
                IDamageable damageable = enemy.GetComponent<IDamageable>();
                damageable.TakeDamage(StatManager.Instance.PlayerStat.damage + StatManager.Instance.ItemTotalStat().attackDamage);
                yield return new WaitForSeconds(GameManager.Instance.GetAttackSpeed());
            }
            yield return null;
        }
    }

    //private IEnumerator AttackAnimationCo(ItemBase item)
    //{
    //    GameObject enemy = FindCloseEnemyInArea(item.so.range);
    //    IDamageable damageable = enemy.GetComponent<IDamageable>();
    //    damageable.TakeDamage(StatManager.Instance.PlayerStat.damage + StatManager.Instance.ItemTotalStat().attackDamage);
        
    //    currentQuaternion = transform.rotation;
    //    targetQuaternion = CheckDot(enemy);

    //    StartCoroutine(RotationAnimation(currentQuaternion, targetQuaternion, GameManager.Instance.GetAttackSpeed() / 2));

    //    yield return new WaitForSeconds(GameManager.Instance.GetAttackSpeed() / 2);

    //    StartCoroutine(RotationAnimation(targetQuaternion, currentQuaternion, GameManager.Instance.GetAttackSpeed() / 2));
    //}

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
    }
}
