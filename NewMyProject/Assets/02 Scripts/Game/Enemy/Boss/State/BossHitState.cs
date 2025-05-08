using Manager;
using MyUtil.FSM;
using NPOI.SS.Formula.Functions;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.State.Part
{
    public class BossHitState : IState
    {
        private BossHealth _health;
        private SpriteRenderer _spriteRenderer;

        private Color _originColor;

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

            _health.StartCoroutine(HitAnimationCo());
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }

        private IEnumerator HitAnimationCo()
        {
            float currentTime = 0;
            while (!GameManager.Instance.GameOver && currentTime < _animationTime)
            {
                currentTime += Time.deltaTime;
                float t = Mathf.Clamp01(currentTime / _animationTime);

                _spriteRenderer.color = Color.Lerp(_originColor, Color.red, t);

                yield return null;
            }

            currentTime = 0;

            while (!GameManager.Instance.GameOver && currentTime < _animationTime)
            {
                currentTime += Time.deltaTime;
                float t = Mathf.Clamp01(currentTime / _animationTime);

                _spriteRenderer.color = Color.Lerp(Color.red, _originColor, t);

                yield return null;
            }

            _health.IsHit = false;
        }
    }
}

