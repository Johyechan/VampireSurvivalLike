using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss.Robot.Pattern;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotLeftArm : BossPartBase
    {
        [SerializeField] private BossPartBase _rightArm;

        protected override void Awake()
        {
            base.Awake();

            Pattern = new RobotLeftArmPattern(this, _rightArm, _attackHandler, _so.minProjectileCount, _so.maxProjectileCount, _so.minFireSpeed, _so.maxFireSpeed, _so.damage);
        }
    }
}

