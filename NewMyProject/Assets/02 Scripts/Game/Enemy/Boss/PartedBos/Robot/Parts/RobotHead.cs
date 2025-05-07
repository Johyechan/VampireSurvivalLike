using Enemy.Boss.Interface;
using Enemy.Boss.Pattern;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Boss.PartedBoss.Robot.Part
{
    public class RobotHead : BossPartBase
    {
        [SerializeField] private BossLaserPatternSO _so;
        private LineRenderer _lineRenderer;

        private void OnDrawGizmos()
        {
            //Vector2 dir = new Vector2(Mathf.Cos(45), Mathf.Sin(45));
            //Gizmos.DrawRay(transform.position, dir * 10);
            //Gizmos.DrawRay(transform.position + new Vector3(0.5f, -0.25f), dir * 10);
            //Gizmos.DrawRay(transform.position + new Vector3(-0.5f, 0.25f), dir * 10);
        }

        protected override void Awake()
        {
            base.Awake();

            _lineRenderer = GetComponent<LineRenderer>();

            Pattern = new RobotHeadPattern(this, _attackHandler, _lineRenderer, _so.patternData);
        }
    }
}

