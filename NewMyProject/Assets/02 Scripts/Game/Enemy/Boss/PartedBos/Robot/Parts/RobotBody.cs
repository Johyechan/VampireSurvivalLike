using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss.Robot.Pattern;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotBody : BossPartBase
    {
        protected override void Awake()
        {
            base.Awake();

            Pattern = new RobotBodyPattern(transform.parent, this, _attackHandler);
        }
    }
}

