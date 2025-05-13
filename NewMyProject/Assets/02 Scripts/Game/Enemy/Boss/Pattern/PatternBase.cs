using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public abstract class PatternBase : IBossPattern
    {
        protected Coroutine _currentCoroutine;

        protected BossPartBase _currentPart;

        protected BossAttackHandler _attackHandler;

        public PatternBase(BossPartBase currentPart, BossAttackHandler attackHandler)
        {
            _currentPart = currentPart;
            _attackHandler = attackHandler;
        }

        public virtual void Pattern()
        {
            _currentCoroutine = _currentPart.StartCoroutine(PatternCo());
        }

        protected abstract IEnumerator PatternCo();

        public virtual void PatternEnd()
        {
            SpriteRenderer spriteRenderer = _currentPart.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.1f);
            if(_currentCoroutine != null)
            {
                _currentPart.StopCoroutine(_currentCoroutine);
                _attackHandler.PatternEnd = true;
            }
        }
    }
}

