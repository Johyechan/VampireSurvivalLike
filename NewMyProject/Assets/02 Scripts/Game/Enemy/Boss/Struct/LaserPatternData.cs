using System;
using UnityEngine;

namespace Enemy.Boss.Struct
{
    [Serializable]
    public struct LaserPatternData
    {
        public float lineWidth;
        public float lineLength;

        public float rotateSpeed;
        public float rotateTime;

        public float startDelay;
        public float rotateStartDelay;
        public float patternEndDelay;
    }
}

