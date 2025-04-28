using Enemy.Boss.PartedBoss;
using MyUtil.FSM;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Boss.Transition
{
    public class BossDeathTransition : ITransition
    {
        private PartedBossBaseController _bossController;

        private StateMachine _machine;

        private IState _deathState;

        public BossDeathTransition(PartedBossBaseController bossController, StateMachine machine, IState deathState)
        {
            _bossController = bossController;
            _machine = machine;
            _deathState = deathState;
        }

        public bool TryTransitionToThisState()
        {
            if(_bossController.IsDeath)
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

