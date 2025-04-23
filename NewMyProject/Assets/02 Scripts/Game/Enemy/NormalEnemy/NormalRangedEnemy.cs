using Enemy;
using Enemy.State;
using Enemy.Strategy.Attack;
using Enemy.Strategy.Move;
using Manager;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Normal
{
    // 원거리 일반 적 유닛 클래스
    public class NormalRangedEnemy : NormalEnemyBase
    {
        [Header("Projectile Setting")]
        [Tooltip("발사체의 타입")]
        [SerializeField] private ObjectPoolType _fireType;

        [Tooltip("발사체의 날아가는 속도")]
        [SerializeField] private float _fireSpeed;

        // 전략 패턴 초기화 및 상태 초기화
        protected override void Awake()
        {
            base.Awake();

            _attackStrategy = new EnemyRangedAttack(transform, _so.attackRange, _so.damage, "Player", _fireType, _fireSpeed);
            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.speed, "Player");

            Init();
        }
    }
}

