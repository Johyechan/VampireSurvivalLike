using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public bool CalculatePercentageToBool(float probability)
    {
        return Random.value < (probability / 100);
    }

    public float AttackSpeedCalculate(float value, float probability)
    {
        return value * (1 + probability / 100);
    }
}
