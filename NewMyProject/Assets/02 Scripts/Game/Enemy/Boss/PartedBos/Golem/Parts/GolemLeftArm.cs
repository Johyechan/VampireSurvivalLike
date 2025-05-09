using Enemy.Boss.Interface;
using Enemy.Boss.Pattern;
using MyUtil.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class GolemLeftArm : BossPartBase
    {
        [SerializeField] private BossCircularFirePatternSO _so;
        [SerializeField] private BossPartBase _rightArm;

        private void Start()
        {
            Pattern = new RobotLeftArmPattern(this, _rightArm, _attackHandler, _so.patternData);
        }
    }
}

