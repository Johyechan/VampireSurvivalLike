using Enemy.Boss.PartedBoss;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Boss.Transition
{
    public class BossDeathTransition : ITransition
    {
        private BossBase _bossBase;

        private StateMachine _machine;

        private IState _deathState;

        public BossDeathTransition(BossBase bossBase, StateMachine machine, IState deathState)
        {
            _bossBase = bossBase;
            _machine = machine;
            _deathState = deathState;
        }

        public bool TryTransitionToThisState()
        {
            if(_bossBase.IsDead)
            {
                if(!_machine.IsCurrentState(_deathState))
                {
                    _machine.ChangeState(_deathState);
                    return true;
                }
            }

            return false;
        }
    }
}

