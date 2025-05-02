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

        protected void DashAnimation(Transform trans, float shakePower)
        {
            float x = (Mathf.PerlinNoise(Time.time * 20f, 0f) - 0.5f) * shakePower;
            float y = (Mathf.PerlinNoise(0f, Time.time * 20f) - 0.5f) * shakePower;
            trans.localPosition = _currentPos + new Vector3(x, y, 0f);
        }

        protected Vector3 FindPlayerDirection(Transform trans)
        {
            Vector3 dir = GameManager.Instance.player.transform.position - trans.position;

            return dir.normalized;
        }
    }
}

