using MyUtil.FSM;
using UnityEngine;

namespace Enemy.Boss.State
{
    public class BossHitState : IState
    {
        private Sprite _sprite;

        public BossHitState(Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Enter()
        {
            Debug.Log("�ǰ� ����");
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

