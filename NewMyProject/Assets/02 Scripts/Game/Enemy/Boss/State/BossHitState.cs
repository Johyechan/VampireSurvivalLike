using MyUtil.FSM;
using NPOI.SS.Formula.Functions;
using UnityEngine;

namespace Enemy.Boss.State.Part
{
    public class BossHitState : IState
    {
        private BossHealth _health;
        private SpriteRenderer _spriteRenderer;

        private Color _originColor;

        private float _currentTime;
        private float _animationTime;

        public BossHitState(BossHealth health, SpriteRenderer spriteRenderer, float animationTime)
        {
            _spriteRenderer = spriteRenderer;
            _animationTime = animationTime;
            _health = health;
        }

        public void Enter()
        {
            _originColor = _spriteRenderer.color;
            _currentTime = 0;
        }

        public void Execute()
        {
            if(_currentTime > _animationTime)
            {
                _health.IsHit = false;
                return;
            }
            
            _currentTime += Time.deltaTime;

            float t = Mathf.Clamp01(_currentTime / _animationTime);

            if (_currentTime < _animationTime / 2)
            {
                _spriteRenderer.color = Color.Lerp(_originColor, Color.red, t * 2);
            }
            else
            {
                _spriteRenderer.color = Color.Lerp(Color.red, _originColor, t * 2);
            }
        }

        public void Exit()
        {
            
        }
    }
}

