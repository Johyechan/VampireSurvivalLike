using Item;
using Manager;
using Manager.Inventory;
using MyUtil.FSM;
using MyUtil.Interface;
using MyUtil.Pool;
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
        private PlayerWallet _wallet;

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
            GameManager.Instance.GameOver = false;

            _backpack = GetComponent<PlayerBackpack>();
            _eventSubscriber = GetComponent<PlayerEventSubscriber>();
            _movement = GetComponent<PlayerMovement>();
            _health = GetComponent<PlayerHealth>();
            _health.MaxHp = playerSO.maxHp;
            _wallet = GetComponent<PlayerWallet>();
            _wallet.CurrentMoney = playerSO.startMoney;

            _animator = GetComponent<Animator>();

            _machine = new StateMachine();

            _idleState = new PlayerIdleState(_animator, _idleHash);
            _moveState = new PlayerMoveState(_animator, _moveHash, transform, _movement);
            _hitState = new PlayerHitState(_animator, _hitHash);
            _deathState = new PlayerDeathState(_animator, _deathHash);

            _machine.ChangeState(_idleState);
        }

        private void OnEnable()
        {
            _eventSubscriber.OnAddItem += AddItem;
            _health.OnHit += Hit;
            _health.OnDie += Die;
            if(InventoryManager.Instance != null)
            {
                InventoryManager.Instance.OnAddItem += AddItem;
            }
        }

        private void OnDisable()
        {
            _eventSubscriber.OnAddItem -= AddItem;
            _health.OnHit -= Hit;
            _health.OnDie -= Die;
            if (InventoryManager.Instance != null)
            {
                InventoryManager.Instance.OnAddItem -= AddItem;
            }
        }

        private void Update()
        {
            if (GameManager.Instance.GameOver)
            {
                return;
            }

            _machine.UpdateExecute();

            Transition();
        }

        private void Transition()
        {
            if (_health.IsDie)
            {
                return;
            }

            if(_health.IsHit)
            {
                _health.IsHit = false;
            }

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

        private void Hit()
        {
            _machine.ChangeState(_hitState);
        }

        private void Die()
        {
            if (!_machine.IsCurrentState(_deathState))
            {
                _machine.ChangeState(_deathState);
            }
        }

        private void AddItem()
        {
            _backpack.ClearItem();
            foreach (var item in InventoryManager.Instance.Items)
            {
                _backpack.AddItem(item.Key, item.Value);
            }

            _backpack.ItemSet();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Money"))
            {
                Money money = collision.GetComponent<Money>();
                if(money != null)
                {
                    _wallet.AddMoney(money.MoneyValue);
                    ObjectPoolManager.Instance.ReturnObj(ObjectPoolType.Money, money.gameObject);
                }
            }
        }
    }
}

