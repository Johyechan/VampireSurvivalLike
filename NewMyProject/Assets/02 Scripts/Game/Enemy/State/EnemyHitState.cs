using Manager;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyHitState : EnemyStateBase
    {
        private Animator _animator;

        private int _hash;

        private Vector2 dir;

        private Transform _trans;

        private float _knockbackTime;
        private float _knockbackPower;

        public EnemyHitState(Animator animator, int hash, Transform trans, float knockbackTime, float knockbackPower)
        {
            _animator = animator;
            _hash = hash;
            _trans = trans;
            _knockbackTime = knockbackTime;
            _knockbackPower = knockbackPower;
        }

        private void OnDisable()
        {
            StopCoroutine(Knockback());
        }

        public override void Enter()
        {
            base.Enter();
            dir = (_trans.position - GameManager.Instance.player.transform.position).normalized;
            StartCoroutine(Knockback());
        }

        private IEnumerator Knockback()
        {
            _animator.SetTrigger(_hash);

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

