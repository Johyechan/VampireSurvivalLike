using Manager;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyHitState : IState
    {
        private Animator _animator;

        private int _hash;

        private Vector2 dir;

        private Transform _trans;

        private float _knockbackPower;

        public EnemyHitState(Animator animator, int hash, Transform trans, float knockbackPower)
        {
            _animator = animator;
            _hash = hash;
            _trans = trans;
            _knockbackPower = knockbackPower;
        }

        public void Enter()
        {
            Debug.Log("적 피격 당함");

            _animator.SetTrigger(_hash);

            dir = (_trans.position - GameManager.Instance.player.transform.position).normalized;
        }

        public void Execute()
        {
            _trans.Translate(dir.normalized * _knockbackPower * Time.deltaTime);
        }

        public void Exit()
        {
            
        }
    }
}

