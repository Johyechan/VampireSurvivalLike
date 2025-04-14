using Enemy.Interface.StateSwitch;
using UnityEngine;

namespace Enemy.StateSwitch
{
    public class EnemyMoveStateSwitch : IEnemyStateSwitch
    {
        public bool IsDelayStateSwitch()
        {
            return false;
        }

        public void StateSwitch(string changeStateName)
        {
            throw new System.NotImplementedException();
        }
    }
}

