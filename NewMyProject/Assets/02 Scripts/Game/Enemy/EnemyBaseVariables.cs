using Enemy.Interface.Strategy;
using MyUtil.FSM;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy
{
    // 작성자: 조혜찬
    // 기본적으로 적이 가지는 변수들
    public class EnemyBaseVariables : MonoBehaviour
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

        protected EnemyKnockbackHandler _knockbackHandler; // 적 넉백

        protected EnemyAttackDelayHandler _attackHandler; // 적 공격

        protected EnemyReSpawn _enemyReSpawn; // 적 재스폰 기능

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

        // 죽음 상태는 외부에서 죽었는지 알아야 작업을 멈추는 경우가 존재 + 자식이 접근 못하는 이유는 죽는 기준은 항상 같기 때문
        public bool IsDie { get { return _isDie; } }
        protected bool _isDie = false;

        public bool IsAttackDelay { get; set; }
        public bool Isknockback { get; set; }

        // 자식이 재정의 가능하게 만듦
        protected virtual void Awake()
        {
            // 체력 관련 시스템을 관리하는 클래스와 애니메이션을 실행 시키기 위한 애니메이터 가져오기
            _health = GetComponent<EnemyHealth>();
            _health.MaxHp = _so.maxHp;
            _knockbackHandler = new EnemyKnockbackHandler(this, transform, _knockbackTime, _knockbackPower);
            _attackHandler = new EnemyAttackDelayHandler(_so, this);
            _animator = GetComponent<Animator>();

            // 새로운 머신 가져와 각자 자식들이 각자만의 머신을 가지도록 설정
            _machine = new StateMachine();
        }
    }
}
// 마지막 작성 일자: 2025.05.15
