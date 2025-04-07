using Manager;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyHitState : EnemyStateBase
    {
        private Vector2 dir;

        private Transform _trans;

        private float _knockbackTime;
        private float _knockbackPower;

        public EnemyHitState(Transform trans, float knockbackTime, float knockbackPower)
        {
            _trans = trans;
            _knockbackTime = knockbackTime;
            _knockbackPower = knockbackPower;
        }

        public override void Enter()
        {
            base.Enter();
            dir = (_trans.position - GameManager.Instance.player.transform.position).normalized;
            StartCoroutine(Knockback());
        }

        private IEnumerator Knockback()
        {
            float currentTime = 0;
            while(currentTime < _knockbackTime)
            {
                currentTime += Time.deltaTime;
                _trans.Translate(dir.normalized * _knockbackPower * Time.deltaTime);
                yield return null;
            }
        }
    }
}

