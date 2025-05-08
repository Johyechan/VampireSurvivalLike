using Enemy.Interface;
using Enemy.State;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;
using UnityEngine.Rendering;

namespace Enemy.Transition.Normal
{
    // �Ϲ� ���� ��� ���� ��ȯ�� ó���ϴ� Ŭ����
    public class NormalDeathStateTransition : ITransition
    {
        private StateMachine _machine;

        private EnemyHealth _health;

        private IState _deathState;

        public NormalDeathStateTransition(StateMachine machine, EnemyHealth health, IState deathState)
        {
            _machine = machine;
            _health = health;
            _deathState = deathState;
        }

        // ���� ��ȯ�� �������� �Ǵ��ϴ� �޼���
        public bool TryTransitionToThisState()
        {
            // ��� �����̸鼭 ���� ���°� �ƴ� ��� ���� ��ȯ �� true ��ȯ
            if (_health.IsDie)
            {
                if (!_machine.IsCurrentState(_deathState))
                {
                    _machine.ChangeState(_deathState);
                }
                return true;
            }
            return false;
        }
    }
}

