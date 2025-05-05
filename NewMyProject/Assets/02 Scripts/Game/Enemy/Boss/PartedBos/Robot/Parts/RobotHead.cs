using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss.Robot.Pattern;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotHead : BossPartBase
    {
        private LineRenderer _lineRenderer;

        protected override void Awake()
        {
            base.Awake();

            _lineRenderer = GetComponent<LineRenderer>();

            //Pattern = new RobotHeadPattern(this, _attackHandler, _lineRenderer);
        }
    }
}

