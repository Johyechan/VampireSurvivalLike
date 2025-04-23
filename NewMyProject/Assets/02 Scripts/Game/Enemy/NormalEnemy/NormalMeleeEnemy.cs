using Enemy.State;
using Enemy.Strategy.Attack;
using Enemy.Strategy.Move;
using Manager;
using MyUtil.Pool;
using UnityEngine;

namespace Enemy.Normal
{
    // 근거리 일반 적 유닛 클래스
    public class NormalMeleeEnemy : NormalEnemyBase
    {
        // 전략 패턴 초기화 및 상태 초기화
        protected override void Awake()
        {
            base.Awake();

            _moveStrategy = new EnemyPlayerFollowMove(transform, GameManager.Instance.player.transform, _so.playerCheckRange, _so.speed, "Player");
            _attackStrategy = new EnemyMeleeAttack(transform, _so.attackRange, _so.damage, "Player");

            Init();
        }
    }
}

