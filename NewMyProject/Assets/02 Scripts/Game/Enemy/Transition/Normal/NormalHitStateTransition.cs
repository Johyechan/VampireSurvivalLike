using Enemy.Interface;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Transition.Normal
{
    // �Ϲ� ���� �ǰ� ���� ��ȯ�� ó���ϴ� Ŭ����
    public class NormalHitStateTransition : ITransition
    {
        private StateMachine _machine;

        private EnemyHealth _health;

        private IState _hitState;

        public NormalHitStateTransition(StateMachine machine, EnemyHealth health, IState hitState)
        {
            _machine = machine;
            _health = health;
            _hitState = hitState;
        }

        // ��ȯ �������� �Ǵ��ϴ� �޼���
        public bool TryTransitionToThisState()
        {
            // �ǰ� ���¶�� ���� ��ȯ �� true ��ȯ 
            // �ߺ� ���� ��ȯ�� ���� ���� IsHit�� false�� ����
            if (_health.IsHit)
            {
                _machine.ChangeState(_hitState);
                _health.IsHit = false;
                return true;
            }

            return false;
        }
    }
}

