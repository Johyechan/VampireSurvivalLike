using Enemy.Interface;
using Manager;
using MyUtil;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    // 근접 공격을 처리하는 클래스
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

        // 공격이 불릴 때 바로 데미지를 가하게 구현
        public override void Attack()
        {
            // 플레이어의 IDamageable을 가져와서 데미지 주기
            IDamageable damageable = GameManager.Instance.player.GetComponent<IDamageable>();
            damageable.TakeDamage(_damage);
        }

        // 공격 범위를 체크
        public override bool CheckArea()
        {
            GameObject player = AreaUtil.CheckArea(_trans, _range, LayerMask.GetMask(_layerMask));

            if (player != null)
                return true;

            return false;
        }
    }
}

