using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackBase, IAttackStrategy
{
    public void Attack(ItemBase item)
    {
        // 근접 공격
        StartCoroutine(AttackCo(item));
    }

    private IEnumerator AttackCo(ItemBase item)
    {
        // 가장 가까운 적 찾기
        // 애니메이션 실행 및 가장 가까운 적 데미지 주기
        // 대기
        // 반복
        yield return null;
    }
}
