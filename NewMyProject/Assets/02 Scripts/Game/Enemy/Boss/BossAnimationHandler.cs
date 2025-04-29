using UnityEngine;

namespace Enemy.Boss
{
    public class BossAnimationHandler
    {
        public Animator BossAnimator { get; set; }

        public int IdleHash { get { return _idleHash; } }
        private int _idleHash = Animator.StringToHash("Idle");
        public int MoveHash { get { return _moveHash; } }
        private int _moveHash = Animator.StringToHash("Move");
        public int DeadHash { get { return _deadHash; } }
        private int _deadHash = Animator.StringToHash("Dead");
    }
}

