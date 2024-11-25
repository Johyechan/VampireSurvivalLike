using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerSO so;

        private StateMachine _stateMachine;

        private PlayerMovement _movement;

        private PlayerHealth _health;

        private IState _idleState;
        private IState _moveState;
        private IState _dieState;

        private bool _isMoving;
        private bool _isDead;

        void Start()
        {
            _isMoving = false;
            _isDead = false;
            
            _movement = GetComponent<PlayerMovement>();

            _health = GetComponent<PlayerHealth>();

            _stateMachine = new StateMachine();

            _idleState = new PlayerIdleState(_movement);
            _moveState = new PlayerMoveState(_movement, so.speed);
            _dieState = new PlayerDieState(_movement);

            _stateMachine.ChangeState(_idleState);
        }

        private void Update()
        {
            if (_health.IsDie && _isDead)
                return;

            if (_health.IsDie && !_isDead)
            {
                _stateMachine.ChangeState(_dieState);
                _isDead = true;
            }

            if (!_isMoving && _movement.MoveKeyDown())
            {
                _stateMachine.ChangeState(_moveState);
                _isMoving = true;
            }

            if(_isMoving && _movement.MoveKeyUp())
            {
                _stateMachine.ChangeState(_idleState);
                _isMoving = false;
            }

            _stateMachine.UpdateExecute();
        }
    }
}

