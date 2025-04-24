using Manager;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    // �˹��� ó���ϴ� Ŭ����
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
            // �˹� ��
            _enemyVariables.Isknockback = true;
            float currentTime = 0;
            // �÷��̾�� �ڽű����� ������ ����
            Vector3 dir = (_trans.position - GameManager.Instance.player.transform.position).normalized;

            // �˹� �ð� ���� �˹��� �Ŀ���ŭ �з�����
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

