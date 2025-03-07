using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyStat
{
    public struct ItemStat
    {
        public float attackDamage; // 물리 데미지
        public float abilityPower; // 마법 데미지
        public float soulPower; // 소울 파워
        public float range; // 공격범위
        public float accuracyRate; // 명중률 - 확률 계산기
        public float avoidanceRate; // 회피률 - 확률 계산기
        public float criticalHitRate; // 치명타 - 확률 계산기
        public float attackSpeed; // 공속 - 비율 증감 계산기
        public float speedIncrease; // 이속 - 비율 증감 계산기
        public float defence; // 방어력
        public float health; // 체력
        public float mana; // 마나
        public float soul; // 소울
        public float healingCost; // 체력 코스트
        public float manaCost; // 마나 코스트
        public float healingSteal; // 피흡 - 비율 증감 계산기
        public float manaSteal; // 마나 흡혈 - 비율 증감 계산기
        public float healingFactor; // 체젠
        public float manaFactor; // 마나젠
    }
}

