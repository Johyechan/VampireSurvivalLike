using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "SO/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public ObjectPoolType fireObjType; // 발사체 (없으면 안 넣어도 됨)
    public ObjectPoolType objType;
    public float fireSpeed; // 발사체 속도 (없으면 안 넣어도 됨)
    public string itemLevel;
    public string no; // 아이템 번호
    public string itemName; // 아이템 이름
    public RoleType role; // 사용가능한 캐릭터
    public float attackDamage; // 물리 데미지
    public float abilityPower; // 마법 데미지
    public float soulPower; // 소울 파워?
    public float range; // 공격범위
    public float accuracyRate; // 명중률 - 확률 계산기
    public float avoidanceRate; // 회피률 - 확률 계산기
    public float criticalHitRate; // 치명타 - 확률 계산기
    public float attackSpeed; // 공속 - 비율 증감 계산기
    public float speedIncrease; // 이속 - 비율 증감 계산기
    public float defence; // 방어력
    public float health; // 체력
    public float mana; // 마나
    public float soul; // 소울?
    public float healingCost; // 체력 코스트
    public float manaCost; // 마나 코스트
    public float healingSteal; // 피흡 - 비율 증감 계산기
    public float manaSteal; // 마나 흡혈 - 비율 증감 계산기
    public float healingFactor; // 체젠
    public float manaFactor; // 마나젠
    public EffectType effect; // 특수효과
    public int price; // 가격
}
