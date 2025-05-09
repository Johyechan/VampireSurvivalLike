using Enemy.Boss.Interface;
using Enemy.Boss.Pattern;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class GolemHead : BossPartBase
    {
        [SerializeField] private BossLaserPatternSO _so;
        private LineRenderer _lineRenderer;

        protected override void Awake()
        {
            base.Awake();

            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            Pattern = new RobotHeadPattern(this, _attackHandler, _lineRenderer, _so.patternData);
        }
    }
}

