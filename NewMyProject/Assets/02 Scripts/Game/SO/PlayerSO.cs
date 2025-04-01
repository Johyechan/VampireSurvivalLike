using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/PlayerSO", order = 0)]
public class PlayerSO : ScriptableObject
{
    public float maxHp;
    public float hpRegen;
    public float damage;
    public float mana;
    public float defence;
    public float avoidanceRate;
    public float attackSpeed;
    public float criticalHitRate;
    public float healingSteal;
    public float speed;

    public int startMoney;
}
