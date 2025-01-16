using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/Weapon", order = 0)]
public class WeaponSO : ScriptableObject
{
    public float power;
    public float attackCoolTime;
    public float speed;
    public float radius;
    public float lifeTime;
}
