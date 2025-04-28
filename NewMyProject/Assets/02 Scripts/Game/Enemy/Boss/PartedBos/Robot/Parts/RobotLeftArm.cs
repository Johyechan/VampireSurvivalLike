using Enemy.Boss.Interface;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotLeftArm : BossPartBase
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

