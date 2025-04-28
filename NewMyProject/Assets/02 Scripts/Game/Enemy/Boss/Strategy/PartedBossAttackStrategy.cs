using Enemy.Boss.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.Strategy
{
    public class PartedBossAttackStrategy : IBossAttackStrategy
    {
        private List<IBossPart> _parts = new();

        public PartedBossAttackStrategy(List<IBossPart> parts)
        {
            _parts = parts;
        }

        public void RandomPattern()
        {
            int randomIndex = Random.Range(0, _parts.Count);
            _parts[randomIndex].RandomPattern();
        }
    }
}

