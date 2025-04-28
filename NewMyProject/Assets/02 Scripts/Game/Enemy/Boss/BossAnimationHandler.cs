using UnityEngine;

namespace Enemy.Boss
{
    public class BossAnimationHandler : MonoBehaviour
    {
        public Animator BossAnimator { get; set; }

        public int IdleHash { get { return _idleHash; } }
        private int _idleHash = Animator.StringToHash("Idle");
        public int MoveHash { get { return _moveHash; } }
        private int _moveHash = Animator.StringToHash("Move");
        public int HitHash { get { return _hitHash; } }
        private int _hitHash = Animator.StringToHash("Hit");
        public int AttackHash { get { return _attackHash; } }
        private int _attackHash = Animator.StringToHash("Attack");
        public int DeathHash { get { return _deathHash; } }
        private int _deathHash = Animator.StringToHash("Death");
    }
}

