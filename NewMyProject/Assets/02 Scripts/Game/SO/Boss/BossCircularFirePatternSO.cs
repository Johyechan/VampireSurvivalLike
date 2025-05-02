using UnityEngine;

[CreateAssetMenu(fileName = "BossCircularFirePatternSO", menuName = "SO/BossSO/PatternSO/CircularFireSO", order = 0)]
public class BossCircularFirePatternSO : BossPatternSO
{
    public int minProjectileCount;
    public int maxProjectileCount;
    public float minFireSpeed;
    public float maxFireSpeed;
}
