using Enemy.Interface;
using Enemy.State;
using Manager;
using MyUtil.FSM;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected EnemySO _so;

        protected Animator _animator;

        protected IEnemyMoveStrategy _moveStrategy;
        protected IEnemyAttackStrategy _attackStrategy;

        protected EnemyHealth _health;

        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _moveState;
        protected IState _attackState;
        protected IState _hitState;
        protected IState _deathState;

        [SerializeField] protected ObjectPoolType _type;

        [SerializeField] protected float _knockbackTime;
        [SerializeField] protected float _knockbackPower;

        public bool IsDie { get { return _isDie; } }
        private bool _isDie = false;

        protected virtual void Awake()
        {
            _health = GetComponent<EnemyHealth>();
            _animator = GetComponent<Animator>();

            _machine = new StateMachine();
        }

        protected virtual void OnEnable()
        {
            _isDie = false;
            _machine.ChangeState(_idleState);
        }

        void Update()
        {
            _machine.UpdateExecute();

            if(_attackStrategy.CheckArea(transform, _so.attackRange, "Player") && !_machine.IsCurrentState(_attackState))
            {
                _machine.ChangeState(_attackState);
            }
            else
            {
                if (_moveStrategy.CheckArea(transform, _so.playerCheckRange, "Player") && !_machine.IsCurrentState(_moveState))
                {
                    _machine.ChangeState(_moveState);
                }
            }
        }

        protected void AnimationEnd()
        {
            _machine.ChangeState(_idleState);
        }

        protected void Return()
        {
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }

        protected void HitEnd()
        {
            _machine.ChangeState(_idleState);
        }

        public void Hit()
        {
            _machine.ChangeState(_hitState);
        }

        public void Death()
        {
            _isDie = true;
            _machine.ChangeState(_deathState);
        }
    }
}