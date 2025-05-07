using Enemy.Boss.Interface;
using Enemy.Boss.Pattern;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotBody : BossPartBase
    {
        [SerializeField] private BossDashPatternSO _so;
        protected override void Awake()
        {
            base.Awake();

            Pattern = new RobotBodyPattern(transform.parent, this, _attackHandler, _so.patternData);
        }
    }
}

