using System;
using UnityEngine;

namespace Enemy.Boss.Struct
{
    [Serializable]
    public struct DashPatternData
    {
        public float dashSpeed;
        public float dashTime;

        public float backMovingSpeed;
        public float backMovingTime;

        public float shakePower;
        public float shakeTime;

        public float patternEndDelay;
    }
}

