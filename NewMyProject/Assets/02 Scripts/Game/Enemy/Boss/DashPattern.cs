using Enemy.Boss.Interface;
using Manager;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss
{
    public abstract class DashPattern : IBossPattern
    {
        protected Vector3 _currentPos = Vector3.zero;

        public abstract void Pattern();

        protected abstract IEnumerator PatternCo();

        protected void ShakeAnimation(Transform trans, float shakePower)
        {
            float noise = Mathf.PerlinNoise(Time.time * 5, Time.time * 5) - 0.5f;
            trans.localPosition = _currentPos + new Vector3(noise * shakePower, noise * shakePower, 0f);
        }

        protected Vector3 FindPlayerDirection(Transform trans)
        {
            Vector3 dir = GameManager.Instance.player.transform.position - trans.position;

            return dir.normalized;
        }
    }
}

