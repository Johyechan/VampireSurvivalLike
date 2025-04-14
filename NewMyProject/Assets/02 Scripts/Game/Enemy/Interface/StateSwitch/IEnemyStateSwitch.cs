using UnityEngine;

namespace Enemy.Interface.StateSwitch
{
    public interface IEnemyStateSwitch
    {
        public bool IsDelayStateSwitch();

        public void StateSwitch(string changeStateName);
    }
}

