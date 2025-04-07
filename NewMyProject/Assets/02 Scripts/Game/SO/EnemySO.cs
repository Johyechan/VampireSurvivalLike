using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/EnemySO", order = 0)]
public class EnemySO : ScriptableObject
{
    public float attackRange;
    public float playerCheckRange;
    public float damage;
    public float speed;
    public float hp;
    public float defence;
    public float attackSpeed;
}
