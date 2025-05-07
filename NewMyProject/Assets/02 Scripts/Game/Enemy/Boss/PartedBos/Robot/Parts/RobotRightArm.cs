using Enemy.Boss.Interface;
using Enemy.Boss.Pattern;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotRightArm : BossPartBase
    {
        [SerializeField] private BossCircularFirePatternSO _so;
        [SerializeField] private BossPartBase _leftArm;
        [SerializeField] private float _fireDelay;

        protected override void Awake()
        {
            base.Awake();

            Pattern = new RobotRightArmPattern(this, _leftArm, _attackHandler, _so.patternData, _fireDelay);
        }
    }
}

