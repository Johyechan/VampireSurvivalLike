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
    // 작성자: 조혜찬
    // 적이 기본적으로 가져야 할 기능들을 가진 클래스
    public abstract class EnemyBase : EnemyBaseVariables
    {
        // 디버그
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _so.attackRange); // 공격 범위
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _so.playerCheckRange); // 플레이어 찾는 범위
        }

        protected virtual void OnEnable()
        {
            // 초기화를 위해 항상 새롭게 생성되면 즉 오브젝트 풀에서 새롭게 가져왔을 경우 살아있는 상태
            IsAttackDelay = false;
            Isknockback = false;
            // 그리고 기본 상태로 상태 변환
            _machine.ChangeState(_idleState);
        }

        void Update()
        {
            // Update에서 반복적으로 각 상태의 Execute를 실행
            if(GameManager.Instance.GameOver)
            {
                return;
            }

            if(_enemyReSpawn.ReSpawnCheck()) // 재스폰 해야할 경우
            {
                _enemyReSpawn.ReSpawn(); // 재스폰
            }

            _machine.UpdateExecute(); // 각 상태의 Update

            if (IsAttackDelay) // 현재 공격이 끝나고
            {
                _attackHandler.AttackDelay(); // 공격 대기 상태 시작
            }

            StateTransition(); // 상태 전이 조건 확인
        }

        // 상태 전이를 구현할 함수
        protected abstract void StateTransition();

        // 공격 상태가 끝났을 때 애니메이션 이벤트로 불리는 함수
        protected void AttackEnd()
        {
            _machine.ChangeState(_idleState);
            IsAttackDelay = true;
        }

        // 유니티 작업 창중 애니메이션 작업창에서 애니메이션 이벤트로 넣기 위한 함수
        protected void Return()
        {
            // 삭제될 때 사망 애니메이션이 끝나고 사라지게 하기 위해서
            StopAllCoroutines();
            GameObject money = ObjectPoolManager.Instance.GetObject(ObjectPoolType.Money);
            money.transform.position = transform.position;
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            // 넉백 중이 아닐 경우 넉백 실행
            if (!Isknockback)
            {
                StartCoroutine(_knockbackHandler.KnockbackCo());
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.15