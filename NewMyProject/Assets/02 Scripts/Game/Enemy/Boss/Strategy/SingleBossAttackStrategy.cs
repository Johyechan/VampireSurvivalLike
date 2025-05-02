using Enemy.Boss.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.Strategy
{
    public class SingleBossAttackStrategy : IBossAttackStrategy
    {
        public Queue<IBossPattern> PatternQueue => throw new System.NotImplementedException();

        public void Pattern()
        {
            throw new System.NotImplementedException();
        }
    }
}

