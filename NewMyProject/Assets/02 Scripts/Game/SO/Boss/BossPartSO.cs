using Enemy.Boss.PartedBoss;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossPartSO", menuName = "SO/BossSO/BossPartSO", order = 2)]
public class BossPartSO : ScriptableObject
{
    public float hitAnimationTime;
    public Dictionary<BossPartBase, int> bossParts;
}
