using Enemy.Boss.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotBody : BossPartBase
    {
        protected override void Awake()
        {
            base.Awake();

            Patterns = new List<IBossPattern>
            {

            };
        }
    }
}

