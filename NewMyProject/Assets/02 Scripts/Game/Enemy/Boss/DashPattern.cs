using Enemy.Boss.Interface;
using Manager;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss
{
    public abstract class DashPattern : IBossPattern
    {
        public abstract void Pattern();

        protected abstract IEnumerator PatternCo();

        protected void ShakeAnimation(Transform trans, float shakePower)
        {
            float noise = Mathf.PerlinNoise(Time.time, 0f);
            trans.localPosition = new Vector3(noise * shakePower, 0f, 0f);
        }

        protected Vector3 FindPlayerDirection(Transform trans)
        {
            Vector3 dir = GameManager.Instance.player.transform.position - trans.position;

            return dir.normalized;
        }
    }
}

