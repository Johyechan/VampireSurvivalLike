using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackBase, IAttackStrategy
{
    public void Attack(ItemBase item)
    {
        // ���� ����
        StartCoroutine(AttackCo(item));
    }

    private IEnumerator AttackCo(ItemBase item)
    {
        // ���� ����� �� ã��
        // �ִϸ��̼� ���� �� ���� ����� �� ������ �ֱ�
        // ���
        // �ݺ�
        yield return null;
    }
}
