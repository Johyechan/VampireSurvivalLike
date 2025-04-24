using Manager;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    // 넉백을 처리하는 클래스
    public class EnemyKnockbackHandler
    {
        private EnemyBaseVariables _enemyVariables;

        private Transform _trans;

        private float _knockbackTime;
        private float _knockbackPower;

        public EnemyKnockbackHandler(EnemyBaseVariables enemyVariables, Transform trans, float knockbackTime, float knockbackPower)
        {
            _enemyVariables = enemyVariables;
            _trans = trans;
            _knockbackTime = knockbackTime;
            _knockbackPower = knockbackPower;
        }

        public IEnumerator KnockbackCo()
        {
            // 넉백 중
            _enemyVariables.Isknockback = true;
            float currentTime = 0;
            // 플레이어에서 자신까지의 방향을 구함
            Vector3 dir = (_trans.position - GameManager.Instance.player.transform.position).normalized;

            // 넉백 시간 동안 넉백의 파워만큼 밀려나기
            while (currentTime < _knockbackTime)
            {
                currentTime += Time.deltaTime;
                _trans.position += dir.normalized * _knockbackPower * Time.deltaTime;
                yield return null;
            }

            _enemyVariables.Isknockback = false;
        }
    }
}

