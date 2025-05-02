using UnityEngine;

[CreateAssetMenu(fileName = "BossDashPatternSO", menuName = "SO/BossSO/PatternSO/DashSO", order = 1)]
public class BossDashPatternSO : BossPatternSO
{
    public float dashSpeed;
    public float dashTime;
    public float backMovingSpeed;
    public float backMovingTime;
    public float shakePower;
    public float shakeTime;
}
