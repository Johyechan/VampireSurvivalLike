using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/Enemy", order = 0)]
public class EnemySO : ScriptableObject
{
    public float hp;
    public float speed;
    public float power;
    public float radius;
    public float attackCoolTime;
}
