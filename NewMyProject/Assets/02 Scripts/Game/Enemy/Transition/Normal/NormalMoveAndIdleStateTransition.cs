using Enemy.Interface;
using Enemy.Interface.Strategy;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // �Ϲ� ���� ������ �Ǵ� ��� ���� ��ȯ�� ó���ϴ� Ŭ����
    public class NormalMoveAndIdleStateTransition : ITransition
    {
        private StateMachine _machine;

        private IEnemyMoveStrategy _moveStrategy;

        private IState _moveState;

        private IState _idleState;

        public NormalMoveAndIdleStateTransition(StateMachine machine, IEnemyMoveStrategy moveStrategy, IState moveState, IState idleState)
        {
            _machine = machine;
            _moveStrategy = moveStrategy;
            _moveState = moveState;
            _idleState = idleState;
        }

        // ��ȯ�� �������� �Ǵ��ϴ� �޼���
        public bool TryTransitionToThisState()
        {
            // ������ ���� �ȿ� �÷��̾ �ִ��� Ȯ��
            if (_moveStrategy.CheckArea())
            {
                // ���� ���°� ������ ���°� �ƴ� ��� ������ ���·� ��ȯ �� true ��ȯ
                if (!_machine.IsCurrentState(_moveState))
                {
                    _machine.ChangeState(_moveState);
                    return true;
                }
            }
            else // ���� �ȿ� �÷��̾ ���ٸ� ��� ���·� ��ȯ �� true ��ȯ
            {
                _machine.ChangeState(_idleState);
                return true;
            }

            return false;
        }
    }
}

