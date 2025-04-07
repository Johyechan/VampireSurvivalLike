using Manager;
using Manager.Inventory;
using MyUtil.FSM;
using Player.Backpack;
using Player.State;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerSO playerSO;

        private PlayerBackpack _backpack;

        private PlayerMovement _movement;

        private PlayerEventSubscriber _eventSubscriber;

        private StateMachine _machine;

        private IState _idleState;
        private IState _moveState;
        private IState _hitState;
        private IState _deathState;

        private void Awake()
        {
            _backpack = GetComponent<PlayerBackpack>();
            _eventSubscriber = GetComponent<PlayerEventSubscriber>();
            _movement = GetComponent<PlayerMovement>();

            _machine = new StateMachine();

            _idleState = new PlayerIdleState();
            _moveState = new PlayerMoveState();
            _hitState = new PlayerHitState();
            _deathState = new PlayerDeathState();

            _machine.ChangeState(_idleState);
        }

        private void OnEnable()
        {
            _eventSubscriber.OnAddItem += AddItem;
        }

        private void OnDisable()
        {
            _eventSubscriber.OnAddItem -= AddItem;
        }

        private void Update()
        {
            _machine.UpdateExecute();

            if(_movement.IsMoving && !_machine.IsCurrentState(_moveState))
            {
                _machine.ChangeState(_moveState);
            }
        }

        private void AddItem()
        {
            foreach (var item in InventoryManager.Instance.Items)
            {
                _backpack.AddItem(item.Key, item.Value);
            }

            _backpack.WeaponPositionSet();
        }
    }
}

