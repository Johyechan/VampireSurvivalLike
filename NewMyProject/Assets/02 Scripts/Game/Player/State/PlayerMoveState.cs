using Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Player.State
{
    public class PlayerMoveState : IState
    {
        private Animator _animator;

        private int _hash;

        private Transform _playerTrans;

        private PlayerMovement _movement;

        public PlayerMoveState(Animator animator, int hash, Transform playerTrans, PlayerMovement movement)
        {
            _animator = animator;
            _hash = hash;
            _playerTrans = playerTrans;
            _movement = movement;
        }

        public void Enter()
        {
            _animator.SetBool(_hash, true);
        }

        public void Execute()
        {
            _playerTrans.Translate(_movement.MoveInput * (StatManager.Instance.PlayerStat.speed + StatManager.Instance.AllStat.speedIncrease) * Time.deltaTime);
        }

        public void Exit()
        {
            _animator.SetBool(_hash, false);
        }
    }
}
