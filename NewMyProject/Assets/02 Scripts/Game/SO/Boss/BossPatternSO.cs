using Enemy.Boss.PartedBoss;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossPatternSO", menuName = "SO/BossSO/BossPatternSO", order = 2)]
public class BossPatternSO : ScriptableObject
{
    public float damage;
    public int minProjectileCount;
    public int maxProjectileCount;
    public float minFireSpeed;
    public float maxFireSpeed;
}
