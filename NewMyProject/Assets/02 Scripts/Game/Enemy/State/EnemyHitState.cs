using Manager;
using MyUtil.FSM;
using System.Collections;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyHitState : IState
    {
        // 공격 당했을 때 애니메이션을 실행 시키기 위한 애니메이터 변수
        private Animator _animator;

        // 애니메이션을 실행 시키기 위한 해시 변수
        private int _hash;

        // 밀려날 방향을 저장하는 변수
        private Vector2 dir;

        // 밀려날 오브젝트를 저장하는 변수
        private Transform _trans;

        // 밀려나는 파워
        private float _knockbackPower;

        // 생성장에서 위에 변수에 필요한 값들을 받아서 할당
        public EnemyHitState(Animator animator, int hash, Transform trans, float knockbackPower)
        {
            _animator = animator;
            _hash = hash;
            _trans = trans;
            _knockbackPower = knockbackPower;
        }

        // 이 상태에 들어왔을 때
        public void Enter()
        {
            Debug.Log("적 피격 당함");

            // 애니메이션 실행
            _animator.SetTrigger(_hash);

            // 밀려나는 방향 결정 - 플레이어로부터 자신의 방향으로 밀려나는 방향을 정함
            dir = (_trans.position - GameManager.Instance.player.transform.position).normalized;
        }

        // 이 상태인 동안
        public void Execute()
        {
            // 밀려나기 시작
            Debug.Log("dddd");
            _trans.position += (Vector3)(dir.normalized * _knockbackPower * Time.deltaTime);
        }

        // 이 상태에서 빠져 나갈 때
        public void Exit()
        {
            Debug.Log("Exit");
        }
    }
}

