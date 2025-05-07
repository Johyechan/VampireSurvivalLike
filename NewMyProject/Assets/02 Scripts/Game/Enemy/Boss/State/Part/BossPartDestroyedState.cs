using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State.Part
{
    public class BossPartDestroyedState : IState
    {
        private BossPartBase _partBase;

        public BossPartDestroyedState(BossPartBase partBase)
        {
            _partBase = partBase;
        }

        public void Enter()
        {
            Debug.Log($"{_partBase.name} »ç¸Á");
            _partBase.gameObject.tag = "Untagged";
            _partBase.gameObject.layer = 0;
            _partBase.PatternEnd();
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

