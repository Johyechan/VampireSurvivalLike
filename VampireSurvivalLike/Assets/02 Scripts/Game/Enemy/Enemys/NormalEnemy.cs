using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class NormalEnemy : EnemyBase
    {
        protected override void Start()
        {
            base.Start();

            _stateMachine.ChangeState(_chaseState);
        }

        protected override void Update()
        {
            base.Update();

            CheckAttackArea(so.radius);
        }
    }
}

