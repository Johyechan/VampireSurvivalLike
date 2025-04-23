using Enemy;
using Enemy.State;
using Enemy.Strategy.Attack;
using Enemy.Strategy.Move;
using Manager;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Normal
{
    // ���Ÿ� �Ϲ� �� ���� Ŭ����
    public class NormalRangedEnemy : NormalEnemyBase
    {
        [Header("Projectile Setting")]
        [Tooltip("�߻�ü�� Ÿ��")]
        [SerializeField] private ObjectPoolType _fireType;

        [Tooltip("�߻�ü�� ���ư��� �ӵ�")]
        [SerializeField] private float _fireSpeed;

        // ���� ���� �ʱ�ȭ �� ���� �ʱ�ȭ
        protected override void Awake()
        {
            base.Awake();

            _attackStrategy = new EnemyRangedAttack(transform, _so.attackRange, _so.damage, "Player", _fireType, _fireSpeed);
            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.speed, "Player");

            Init();
        }
    }
}

