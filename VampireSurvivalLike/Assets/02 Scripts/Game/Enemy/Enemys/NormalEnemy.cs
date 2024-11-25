using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class NormalEnemy : EnemyBase
    {
        [SerializeField] protected float _outDistance;

        protected override void OnEnable()
        {
            base.OnEnable();

            _isDead = false;

            _stateMachine.ChangeState(_chaseState);
        }

        protected override void Update()
        {
            base.Update();

            CheckAttackArea(so.radius);

            OutCheck(_outDistance);
        }
    }
}

