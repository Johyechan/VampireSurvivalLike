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
    public abstract class EnemyBase : EnemyBaseVariables
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _so.attackRange);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _so.playerCheckRange);
        }

        protected virtual void OnEnable()
        {
            // 초기화를 위해 항상 새롭게 생성되면 즉 오브젝트 풀에서 새롭게 가져왔을 경우 살아있는 상태
            _isDie = false;
            IsAttackDelay = false;
            Isknockback = false;
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

            if (IsAttackDelay)
            {
                _attackHandler.AttackDelay();
            }

            StateTransition();
        }

        protected abstract void StateTransition();

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