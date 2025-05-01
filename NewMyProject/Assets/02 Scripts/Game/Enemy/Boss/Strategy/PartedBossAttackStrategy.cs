using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.Strategy
{
    public class PartedBossAttackStrategy : IBossAttackStrategy
    {
        private List<BossPartBase> _parts = new();

        public PartedBossAttackStrategy(List<BossPartBase> parts)
        {
            _parts = parts;
        }

        public void RandomPattern()
        {
            List<BossPartBase> aliveParts = _parts.FindAll(part => !part.IsDead);

            if (aliveParts.Count == 0)
                return;

            int randomIndex = Random.Range(0, aliveParts.Count);
            aliveParts[randomIndex].RandomPattern();
        }
    }
}

