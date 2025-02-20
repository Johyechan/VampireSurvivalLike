using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "SO/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public ObjectPoolType FireObjType; // 발사체 (없으면 안 넣어도 됨)
    public ObjectPoolType ObjType;
    public float FireSpeed; // 발사체 속도 (없으면 안 넣어도 됨)
    public int No; // 아이템 번호
    public string Name; // 아이템 이름
    public RoleType Role; // 사용가능한 캐릭터
    public int AttackDamage; // 물리 데미지
    public int AbilityPower; // 마법 데미지
    public int SoulPower; // 소울 파워?
    public int Range; // 공격범위
    public float AccuracyRate; // 명중률 - 확률 계산기
    public float AvoidanceRate; // 회피률 - 확률 계산기
    public float CriticalHitRate; // 치명타 - 확률 계산기
    public float AttackSpeed; // 공속 - 비율 증감 계산기
    public float SpeedIncrease; // 이속 - 비율 증감 계산기
    public int Defence; // 방어력
    public int Health; // 체력
    public int Mana; // 마나
    public int Soul; // 소울?
    public int HealingCost; // 체력 코스트
    public int ManaCost; // 마나 코스트
    public float HealingSteal; // 피흡 - 비율 증감 계산기
    public float ManaSteal; // 마나 흡혈 - 비율 증감 계산기
    public int HealingFactor; // 체젠
    public int ManaFactor; // 마나젠
    public EffectType Effect; // 특수효과
    public int Price; // 가격
}
