using System;
using UnityEngine;

namespace Enemy.Boss.Struct
{
    [Serializable]
    public struct CircularFirePatternData
    {
        public int minProjectileCount;
        public int maxProjectileCount;

        public float minFireSpeed;
        public float maxFireSpeed;

        public float projectileDamage;

        public float patternEndDelay;
    }
}

