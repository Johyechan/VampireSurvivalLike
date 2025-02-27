using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "SO/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public ObjectPoolType fireObjType; // �߻�ü (������ �� �־ ��)
    public ObjectPoolType objType;
    public float fireSpeed; // �߻�ü �ӵ� (������ �� �־ ��)
    public string itemLevel;
    public string no; // ������ ��ȣ
    public string itemName; // ������ �̸�
    public RoleType role; // ��밡���� ĳ����
    public float attackDamage; // ���� ������
    public float abilityPower; // ���� ������
    public float soulPower; // �ҿ� �Ŀ�?
    public float range; // ���ݹ���
    public float accuracyRate; // ���߷� - Ȯ�� ����
    public float avoidanceRate; // ȸ�Ƿ� - Ȯ�� ����
    public float criticalHitRate; // ġ��Ÿ - Ȯ�� ����
    public float attackSpeed; // ���� - ���� ���� ����
    public float speedIncrease; // �̼� - ���� ���� ����
    public float defence; // ����
    public float health; // ü��
    public float mana; // ����
    public float soul; // �ҿ�?
    public float healingCost; // ü�� �ڽ�Ʈ
    public float manaCost; // ���� �ڽ�Ʈ
    public float healingSteal; // ���� - ���� ���� ����
    public float manaSteal; // ���� ���� - ���� ���� ����
    public float healingFactor; // ü��
    public float manaFactor; // ������
    public EffectType effect; // Ư��ȿ��
    public int price; // ����
}
