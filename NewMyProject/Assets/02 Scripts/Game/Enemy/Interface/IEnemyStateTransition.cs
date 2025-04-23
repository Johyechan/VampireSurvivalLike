using UnityEngine;

namespace Enemy.Interface
{
    public interface IEnemyStateTransition
    {
        public bool TryTransitionToThisState();
    }
}

