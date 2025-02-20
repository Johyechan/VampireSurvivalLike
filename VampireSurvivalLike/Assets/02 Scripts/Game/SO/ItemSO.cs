using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "SO/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public ObjectPoolType FireObjType; // �߻�ü (������ �� �־ ��)
    public ObjectPoolType ObjType;
    public float FireSpeed; // �߻�ü �ӵ� (������ �� �־ ��)
    public int No; // ������ ��ȣ
    public string Name; // ������ �̸�
    public RoleType Role; // ��밡���� ĳ����
    public int AttackDamage; // ���� ������
    public int AbilityPower; // ���� ������
    public int SoulPower; // �ҿ� �Ŀ�?
    public int Range; // ���ݹ���
    public float AccuracyRate; // ���߷� - Ȯ�� ����
    public float AvoidanceRate; // ȸ�Ƿ� - Ȯ�� ����
    public float CriticalHitRate; // ġ��Ÿ - Ȯ�� ����
    public float AttackSpeed; // ���� - ���� ���� ����
    public float SpeedIncrease; // �̼� - ���� ���� ����
    public int Defence; // ����
    public int Health; // ü��
    public int Mana; // ����
    public int Soul; // �ҿ�?
    public int HealingCost; // ü�� �ڽ�Ʈ
    public int ManaCost; // ���� �ڽ�Ʈ
    public float HealingSteal; // ���� - ���� ���� ����
    public float ManaSteal; // ���� ���� - ���� ���� ����
    public int HealingFactor; // ü��
    public int ManaFactor; // ������
    public EffectType Effect; // Ư��ȿ��
    public int Price; // ����
}
