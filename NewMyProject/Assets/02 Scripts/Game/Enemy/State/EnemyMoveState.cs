using MyUtil.FSM;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyMoveState : IState
    {
        private EnemyMovement _movement;

        private Transform _trans;

        private Vector3 _target;

        private float _speed;

        public EnemyMoveState(EnemyMovement movement, Transform trans, Vector3 target, float speed)
        {
            _movement = movement;
            _trans = trans;
            _target = target;
            _speed = speed;
        }

        public void Enter()
        {
            
        }

        public void Execute()
        {
            Vector2 dir = _target - _trans.position;

            _movement.Move(dir, _speed);
        }

        public void Exit()
        {
            
        }
    }
}

