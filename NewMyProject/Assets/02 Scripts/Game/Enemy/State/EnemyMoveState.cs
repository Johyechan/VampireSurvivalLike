using Enemy.Interface;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyMoveState : IState
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

        public void Enter()
        {
            _animator.SetBool(_hash, true);
        }

        public void Execute()
        {
            Debug.Log("적 움직임");

            Vector2 dir = _target - _trans.position;

            _moveStrategy.Move(_trans, dir, _speed);
        }

        public void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}

