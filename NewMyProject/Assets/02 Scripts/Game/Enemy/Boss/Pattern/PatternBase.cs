using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public abstract class PatternBase : IBossPattern
    {
        protected BossPartBase _currentPart;

        protected BossAttackHandler _attackHandler;

        public PatternBase(BossPartBase currentPart, BossAttackHandler attackHandler)
        {
            _currentPart = currentPart;
            _attackHandler = attackHandler;
        }

        public virtual void Pattern()
        {
            _currentPart.StartCoroutine(PatternCo());
        }

        protected abstract IEnumerator PatternCo();

        public virtual void PatternEnd()
        {
            SpriteRenderer spriteRenderer = _currentPart.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.1f);
            _currentPart.StopCoroutine(PatternCo());
        }
    }
}

