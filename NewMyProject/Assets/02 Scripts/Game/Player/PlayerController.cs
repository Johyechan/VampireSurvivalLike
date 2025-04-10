using Manager;
using Manager.Inventory;
using MyUtil.FSM;
using MyUtil.Interface;
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
        private PlayerHealth _health;

        private Animator _animator;

        private StateMachine _machine;

        private IState _idleState;
        private IState _moveState;
        private IState _hitState;
        private IState _deathState;

        private int _idleHash = Animator.StringToHash("Idle");
        private int _moveHash = Animator.StringToHash("Move");
        private int _hitHash = Animator.StringToHash("Hit");
        private int _deathHash = Animator.StringToHash("Death");

        private void Awake()
        {
            _backpack = GetComponent<PlayerBackpack>();
            _eventSubscriber = GetComponent<PlayerEventSubscriber>();
            _movement = GetComponent<PlayerMovement>();
            _health = GetComponent<PlayerHealth>();
            _health.MaxHp = playerSO.maxHp;

            _animator = GetComponent<Animator>();

            _machine = new StateMachine();

            _idleState = new PlayerIdleState(_animator, _idleHash);
            _moveState = new PlayerMoveState(_animator, _moveHash);
            _hitState = new PlayerHitState(_animator, _hitHash);
            _deathState = new PlayerDeathState(_animator, _deathHash);

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

            if(_health.IsDie)
            {
                if(!_machine.IsCurrentState(_deathState))
                {
                    _machine.ChangeState(_deathState);
                }
            }
            else
            {
                if (_health.IsHit)
                {
                    _machine.ChangeState(_hitState);
                    _health.IsHit = false;
                }
                else
                {
                    if (_movement.IsMoving)
                    {
                        if (!_machine.IsCurrentState(_moveState))
                        {
                            _machine.ChangeState(_moveState);
                        }
                    }
                    else
                    {
                        _machine.ChangeState(_idleState);
                    }
                }
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

