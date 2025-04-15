using Enemy.Interface;
using Enemy.Interface.Strategy;
using Enemy.State;
using Manager;
using MyUtil.FSM;
using MyUtil.Pool;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    // ���� �⺻������ ������ �� ��ɵ��� ���� Ŭ����
    public abstract class EnemyBase : MonoBehaviour
    {
        // �⺻������ ���� �ɷ�ġ���� �����ϴ� SO�� ������ �־�� ��
        // �̰��� ��� �޴� Ŭ������ ��밡���ϰ� protected�� ���� ������ ����
        [SerializeField] protected EnemySO _so;

        // ���� �ִϸ����� ���� �ڽĵ鵵 ������ ��
        protected Animator _animator;

        // ���� ���, ������ ��� ���� �ڽĵ��� ������ ��
        protected IEnemyMoveStrategy _moveStrategy;
        protected IEnemyAttackStrategy _attackStrategy;

        // ü�� ���� �ڽĵ��� ������ ��
        protected EnemyHealth _health;

        // ���¸� ��ȯ ��Ű�� �ӽŵ� �ڽĵ��� ������ �� �� �� ����
        protected StateMachine _machine;

        // �� ���µ� ���� �ڽĵ��� ���� �����ؾ� Ư���� ���� ���� �� �����ϴٰ� �Ǵ�
        protected IState _idleState;
        protected IState _moveState;
        protected IState _attackState;
        protected IState _hitState;
        protected IState _deathState;

        // �ڽ��� � Ÿ���� ������Ʈ Ǯ���� �ڽ��� ���� ���� �ϱ� ���� ����
        [SerializeField] protected ObjectPoolType _type;

        // ������ �з����� ��ġ�� �ð��� �ٸ��� �ϱ� ���ؼ� �ڽĵ鵵 �˾ƾ� ��
        [SerializeField] protected float _knockbackTime;
        [SerializeField] protected float _knockbackPower;

        private float _currentAttackDelayTime = 0;
        private float _currentHittingDelayTime = 0;

        // ���� ���´� �ܺο��� �׾����� �˾ƾ� �۾��� ���ߴ� ��찡 ���� + �ڽ��� ���� ���ϴ� ������ �״� ������ �׻� ���� ����
        public bool IsDie { get { return _isDie; } }
        private bool _isDie = false;

        protected bool _isAttackDelay = false;
        protected bool _isHittingDelay = false;

        // �ڽ��� ������ �����ϰ� ����
        protected virtual void Awake()
        {
            // ü�� ���� �ý����� �����ϴ� Ŭ������ �ִϸ��̼��� ���� ��Ű�� ���� �ִϸ����� ��������
            _health = GetComponent<EnemyHealth>();
            _health.MaxHp = _so.maxHp;
            _animator = GetComponent<Animator>();

            // ���ο� �ӽ� ������ ���� �ڽĵ��� ���ڸ��� �ӽ��� �������� ����
            _machine = new StateMachine();
        }

        protected virtual void OnEnable()
        {
            // �ʱ�ȭ�� ���� �׻� ���Ӱ� �����Ǹ� �� ������Ʈ Ǯ���� ���Ӱ� �������� ��� ����ִ� ����
            _isDie = false;
            // �׸��� �⺻ ���·� ���� ��ȯ
            _machine.ChangeState(_idleState);
        }

        void Update()
        {
            // Update���� �ݺ������� �� ������ Execute�� ����
            if(GameManager.Instance.gameOver)
            {
                return;
            }

            _machine.UpdateExecute();

            if(_isHittingDelay)
            {
                HittingDelay();
            }

            if(_isAttackDelay)
            {
                AttackDelay();
            }

            StateTransition();
        }

        protected abstract void StateTransition();

        private void AttackDelay()
        {
            _currentAttackDelayTime += Time.deltaTime;

            if(_currentAttackDelayTime > (1 / _so.attackSpeed))
            {
                _isAttackDelay = false;
                _currentAttackDelayTime = 0;
            }
        }

        private void HittingDelay()
        {
            _currentHittingDelayTime += Time.deltaTime;

            if(_currentHittingDelayTime > _knockbackTime)
            {
                _isHittingDelay = false;
                _currentHittingDelayTime = 0;
            }
        }

        protected void AttackEnd()
        {
            _machine.ChangeState(_idleState);
            _isAttackDelay = true;
        }

        // ����Ƽ �۾� â�� �ִϸ��̼� �۾�â���� �ִϸ��̼� �̺�Ʈ�� �ֱ� ���� �Լ�
        protected void HittingStart()
        {
            // �ִϸ��̼��� ������ �⺻ ���·� ���ư��� �ϴ� ���µ��� ���ؼ� ���� �Լ�
            _isHittingDelay = true;
        }

        // ����Ƽ �۾� â�� �ִϸ��̼� �۾�â���� �ִϸ��̼� �̺�Ʈ�� �ֱ� ���� �Լ�
        protected void Return()
        {
            // ������ �� ��� �ִϸ��̼��� ������ ������� �ϱ� ���ؼ�
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }
    }
}