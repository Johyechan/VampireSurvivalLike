using Enemy.State;
using Enemy.Transition.Normal;
using MyUtil;
using MyUtil.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Normal
{
    // �Ϲ� ���� ���� ������ ó���ϴ� ��� Ŭ����
    public class NormalEnemyBase : EnemyBase
    {
        // �ִϸ��̼� �ؽð�
        protected int _moveHash = Animator.StringToHash("Move");
        protected int _attackHash = Animator.StringToHash("Attack");
        protected int _hitHash = Animator.StringToHash("Hit");
        protected int _deathHash = Animator.StringToHash("Death");
        protected int _idleHash = Animator.StringToHash("Idle");

        // ���� ��ȯ�� ó���ϴ� ������
        private ITransition _deathTransition;
        private ITransition _hitTransition;
        private ITransition _knockbackTransition;
        private ITransition _attackTransition;
        private ITransition _moveAndIdleTransition;

        // ���� ��ȯ�� ó���ϴ� �������� ó�� ������� ������ ����Ʈ
        private List<ITransition> _transitions;

        // ���� ��ȯ�� �����ϴ� Ŭ����
        private TransitionHandler _transitionHandler;

        // ���� �ʱ�ȭ
        protected void Init()
        {
            _idleState = new EnemyIdleState(_animator, _idleHash);
            _moveState = new EnemyMoveState(_animator, _moveHash, _moveStrategy);
            _attackState = new EnemyAttackState(_animator, _attackHash, _attackStrategy);
            _hitState = new EnemyHitState(_animator, _hitHash);
            _deathState = new EnemyDeathState(_animator, _deathHash);

            _deathTransition = new NormalDeathStateTransition(_machine, _health, _deathState);
            _hitTransition = new NormalHitStateTransition(_machine, _health, _hitState);
            _knockbackTransition = new NormalKnockbackTransition(this);
            _attackTransition = new NormalAttackStateTransition(_machine, _attackState, this, _attackStrategy);
            _moveAndIdleTransition = new NormalMoveAndIdleStateTransition(_machine, _moveStrategy, _moveState, _idleState);

            _transitions = new List<ITransition>
            {
                _deathTransition,
                _hitTransition,
                _knockbackTransition,
                _attackTransition,
                _moveAndIdleTransition,
            };

            _transitionHandler = new TransitionHandler(_transitions);
        }

        // ���� ���¸� ��Ȳ�� ���� ��ȯ
        protected override void StateTransition()
        {
            if (_transitionHandler.HandleTransitions()) return;
        }
    }
}