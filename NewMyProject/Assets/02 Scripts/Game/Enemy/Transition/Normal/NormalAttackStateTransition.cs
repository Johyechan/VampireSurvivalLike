using Enemy.Interface;
using Enemy.Interface.Strategy;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // �Ϲ� ���� ���� ���� ��ȯ�� ó���ϴ� Ŭ����
    public class NormalAttackStateTransition : ITransition
    {
        private StateMachine _machine;

        private IState _attackState;

        private EnemyBaseVariables _enemyVariables;

        private IEnemyAttackStrategy _attackStrategy;

        public NormalAttackStateTransition(StateMachine machine, IState attackState, EnemyBaseVariables enemyVariables, IEnemyAttackStrategy attackStrategy)
        {
            _machine = machine;
            _attackState = attackState;
            _enemyVariables = enemyVariables;
            _attackStrategy = attackStrategy;
        }

        // ���� ���·� ��ȯ �������� �Ǵ��ϴ� �޼���
        public bool TryTransitionToThisState()
        {
            // ���� ���� �ȿ� �ְ� ���� ���� �ƴ� ��� true ��ȯ �� ���� ��ȭ
            if (_attackStrategy.CheckArea())
            {
                if (!_enemyVariables.IsAttackDelay)
                {
                    _enemyVariables.IsAttackDelay = true;
                    _machine.ChangeState(_attackState);
                    return true;
                }
            }

            return false;
        }
    }
}

