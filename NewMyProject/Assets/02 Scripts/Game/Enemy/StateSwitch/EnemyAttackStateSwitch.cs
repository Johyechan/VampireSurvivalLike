using Enemy.Interface.StateSwitch;
using UnityEngine;

namespace Enemy.StateSwitch
{
    public class EnemyAttackStateSwitch : IEnemyStateSwitch
    {
        public bool IsDelayStateSwitch()
        {
            return true;
        }

        public void StateSwitch(string changeStateName)
        {
            throw new System.NotImplementedException();
        }
    }
}

