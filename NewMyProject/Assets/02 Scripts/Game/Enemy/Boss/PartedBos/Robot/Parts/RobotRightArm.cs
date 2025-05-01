using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss.Robot.Pattern;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotRightArm : BossPartBase
    {
        [SerializeField] private BossPartBase _leftArm;

        protected override void Awake()
        {
            base.Awake();

            Patterns = new List<IBossPattern>
            {
                new RobotRightArmPattern(this, _leftArm, _attackHandler, _so.minProjectileCount, _so.maxProjectileCount, _so.minFireSpeed, _so.maxFireSpeed, _so.damage)
            };
        }
    }
}

