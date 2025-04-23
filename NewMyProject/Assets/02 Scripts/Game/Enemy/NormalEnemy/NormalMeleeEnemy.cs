using Enemy.State;
using Enemy.Strategy.Attack;
using Enemy.Strategy.Move;
using Manager;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Normal
{
    // �ٰŸ� �Ϲ� �� ���� Ŭ����
    public class NormalMeleeEnemy : NormalEnemyBase
    {
        // ���� ���� �ʱ�ȭ �� ���� �ʱ�ȭ
        protected override void Awake()
        {
            base.Awake();

            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.speed, "Player");
            _attackStrategy = new EnemyMeleeAttack(transform, _so.attackRange, _so.damage, "Player");

            Init();
        }
    }
}

