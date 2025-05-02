using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.Strategy
{
    public class PartedBossAttackStrategy : IBossAttackStrategy
    {
        private Queue<BossPartBase> _partDestroyedCheckQueue = new ();

        public PartedBossAttackStrategy(IEnumerable<BossPartBase> parts)
        {
            foreach(var part in parts)
            {
                _partDestroyedCheckQueue.Enqueue(part);
            }
        }

        public void Pattern()
        {
            int count = _partDestroyedCheckQueue.Count;

            while(count-- > 0)
            {
                BossPartBase part = _partDestroyedCheckQueue.Dequeue();

                if (!part.IsDead)
                {
                    part.Pattern.Pattern();
                    _partDestroyedCheckQueue.Enqueue(part);
                    return;
                }
            }
        }
    }
}

