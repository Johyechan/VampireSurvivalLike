using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MeleeAttack : AttackBase, IAttackStrategy
{
    private ItemBase _item;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _item.so.range);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(AttackCo(_item));
        StopCoroutine(AttackAnimationCo(_item));
        StopCoroutine(RotationAnimation(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90), 0.2f));
    }
    public void Attack(ItemBase item)
    {
        _item = item;
        // ���� ����
        StartCoroutine(AttackCo(item));
    }

    private IEnumerator AttackCo(ItemBase item)
    {
        while(true) // �÷��̾� �ױ� ������
        {
            // ���� ����� �� ã��
            if (CheckEnemyInArea(item.so.range))
            {
                StartCoroutine(AttackAnimationCo(item));
            }
            // �ִϸ��̼� ���� �� ���� ����� �� ������ �ֱ�
            // ���
            // �ݺ�
            yield return null;
        }
    }

    private IEnumerator AttackAnimationCo(ItemBase item)
    {
        Quaternion currentQuaternion = transform.rotation;
        Quaternion targetQuaternion = Quaternion.Euler(currentQuaternion.x, currentQuaternion.y, 90);

        GameObject enemy = FindCloseEnemyInArea(item.so.range);
        IDamageable damageable = enemy.GetComponent<IDamageable>();
        damageable.TakeDamage(StatManager.Instance.PlayerStat.damage + StatManager.Instance.ItemTotalStat().attackDamage);

        StartCoroutine(RotationAnimation(currentQuaternion, targetQuaternion, 0.2f));

        yield return new WaitForSeconds(0.2f);

        StartCoroutine(RotationAnimation(targetQuaternion, currentQuaternion, 0.2f));
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
    }
}
