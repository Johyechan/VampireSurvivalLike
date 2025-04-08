using Enemy.Interface;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyMoveState : EnemyStateBase
    {
        private Animator _animator;

        private int _hash;

        private IEnemyMoveStrategy _moveStrategy;

        private Transform _trans;

        private Vector3 _target;

        private float _speed;

        public EnemyMoveState(Animator animator, int hash, IEnemyMoveStrategy moveStrategy, Transform trans, Vector3 target, float speed)
        {
            _animator = animator;
            _hash = hash;
            _moveStrategy = moveStrategy;
            _trans = trans;
            _target = target;
            _speed = speed;
        }

        public override void Enter()
        {
            base.Enter();

            _animator.SetBool(_hash, true);
        }

        public override void Execute()
        {
            Vector2 dir = _target - _trans.position;

            _moveStrategy.Move(_trans, dir, _speed);
        }

        public override void Exit()
        {
            base.Exit();

            _animator.SetBool(_hash, false);
        }
    }
}

