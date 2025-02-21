using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemStat
{
    public int attackDamage; // 물리 데미지
    public int abilityPower; // 마법 데미지
    public int soulPower; // 소울 파워?
    public int range; // 공격범위
    public float accuracyRate; // 명중률 - 확률 계산기
    public float avoidanceRate; // 회피률 - 확률 계산기
    public float criticalHitRate; // 치명타 - 확률 계산기
    public float attackSpeed; // 공속 - 비율 증감 계산기
    public float speedIncrease; // 이속 - 비율 증감 계산기
    public int defence; // 방어력
    public int health; // 체력
    public int mana; // 마나
    public int soul; // 소울?
    public int healingCost; // 체력 코스트
    public int manaCost; // 마나 코스트
    public float healingSteal; // 피흡 - 비율 증감 계산기
    public float manaSteal; // 마나 흡혈 - 비율 증감 계산기
    public int healingFactor; // 체젠
    public int manaFactor; // 마나젠
}
