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
    // 적이 기본적으로 가져야 할 기능들을 가진 클래스
    public abstract class EnemyBase : MonoBehaviour
    {
        // 기본적으로 적의 능력치들을 보유하는 SO를 가지고 있어야 함
        // 이것을 상속 받는 클래스도 사용가능하게 protected로 접근 제한자 설정
        [SerializeField] protected EnemySO _so;

        // 적의 애니메이터 또한 자식들도 가져야 함
        protected Animator _animator;

        // 공격 방식, 움직임 방식 또한 자식들이 가져야 함
        protected IEnemyMoveStrategy _moveStrategy;
        protected IEnemyAttackStrategy _attackStrategy;

        // 체력 또한 자식들이 가져야 함
        protected EnemyHealth _health;

        // 상태를 변환 시키는 머신도 자식들이 가져야 할 수 도 있음
        protected StateMachine _machine;

        // 각 상태들 또한 자식들이 접근 가능해야 특수한 적을 만들 때 유리하다고 판단
        protected IState _idleState;
        protected IState _moveState;
        protected IState _attackState;
        protected IState _hitState;
        protected IState _deathState;

        // 자신이 어떤 타입의 오브젝트 풀인지 자식이 직접 결정 하기 위한 변수
        [SerializeField] protected ObjectPoolType _type;

        // 적마다 밀려나는 수치와 시간을 다르게 하기 위해서 자식들도 알아야 함
        [SerializeField] protected float _knockbackTime;
        [SerializeField] protected float _knockbackPower;

        private float _currentAttackDelayTime = 0;
        private float _currentHittingDelayTime = 0;

        // 죽음 상태는 외부에서 죽었는지 알아야 작업을 멈추는 경우가 존재 + 자식이 접근 못하는 이유는 죽는 기준은 항상 같기 때문
        public bool IsDie { get { return _isDie; } }
        private bool _isDie = false;

        protected bool _isAttackDelay = false;
        protected bool _isHittingDelay = false;

        // 자식이 재정의 가능하게 만듦
        protected virtual void Awake()
        {
            // 체력 관련 시스템을 관리하는 클래스와 애니메이션을 실행 시키기 위한 애니메이터 가져오기
            _health = GetComponent<EnemyHealth>();
            _health.MaxHp = _so.maxHp;
            _animator = GetComponent<Animator>();

            // 새로운 머신 가져와 각자 자식들이 각자만의 머신을 가지도록 설정
            _machine = new StateMachine();
        }

        protected virtual void OnEnable()
        {
            // 초기화를 위해 항상 새롭게 생성되면 즉 오브젝트 풀에서 새롭게 가져왔을 경우 살아있는 상태
            _isDie = false;
            // 그리고 기본 상태로 상태 변환
            _machine.ChangeState(_idleState);
        }

        void Update()
        {
            // Update에서 반복적으로 각 상태의 Execute를 실행
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

        // 유니티 작업 창중 애니메이션 작업창에서 애니메이션 이벤트로 넣기 위한 함수
        protected void HittingStart()
        {
            // 애니메이션이 끝나고 기본 상태로 돌아가야 하는 상태들을 위해서 만든 함수
            _isHittingDelay = true;
        }

        // 유니티 작업 창중 애니메이션 작업창에서 애니메이션 이벤트로 넣기 위한 함수
        protected void Return()
        {
            // 삭제될 때 사망 애니메이션이 끝나고 사라지게 하기 위해서
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }
    }
}