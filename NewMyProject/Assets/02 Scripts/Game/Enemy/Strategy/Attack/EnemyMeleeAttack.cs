using Enemy.Interface;
using Manager;
using MyUtil;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    // ���� ������ ó���ϴ� Ŭ����
    public class EnemyMeleeAttack : EnemyAttackStrategyBase
    {
        private Transform _trans;

        private float _range;
        private float _damage;

        private string _layerMask;

        public EnemyMeleeAttack(Transform trans, float range, float damage, string layerMask)
        {
            _trans = trans;
            _range = range;
            _damage = damage;
            _layerMask = layerMask;
        }

        // ������ �Ҹ� �� �ٷ� �������� ���ϰ� ����
        public override void Attack()
        {
            // �÷��̾��� IDamageable�� �����ͼ� ������ �ֱ�
            IDamageable damageable = GameManager.Instance.player.GetComponent<IDamageable>();
            damageable.TakeDamage(_damage);
        }

        // ���� ������ üũ
        public override bool CheckArea()
        {
            GameObject player = AreaUtil.CheckArea(_trans, _range, LayerMask.GetMask(_layerMask));

            if (player != null)
                return true;

            return false;
        }
    }
}

