using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


namespace Manager
{
    public class LightManager : MonoSingleton<LightManager>
    {
        [SerializeField] private Light2D _globalLight;
        [SerializeField] private Light2D _fovLight;

        [SerializeField] private List<Light2D> _waveringLights = new List<Light2D>();

        [SerializeField] private float _waveringMinValue;
        [SerializeField] private float _waveringDelay;

        public float FovLightRadius { get { return _fovLight.pointLightOuterRadius; } }

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            WaveringLights();
        }

        public void SetFOVRadius(float radius)
        {
            _fovLight.pointLightOuterRadius = radius;
        }

        private void WaveringLights()
        {
            foreach (var light in _waveringLights)
            {
                float _waveringMax = light.pointLightOuterRadius;
                float _waveringMin = light.pointLightOuterRadius - _waveringMinValue;
                StartCoroutine(WaveringCo(light, _waveringMin, _waveringMax, _waveringDelay));
            }
        }

        private IEnumerator WaveringCo(Light2D light, float min, float max, float delay)
        {
            float currentTime = 0;
            float currentRadius = max;

            bool isMax = true;

            while (!GameManager.Instance.playerDead) // 플레이어 죽기전까지
            {
                if (currentTime >= delay)
                {
                    currentTime = 0;
                }

                currentTime += Time.deltaTime;
                float t = Mathf.Clamp01(currentTime / delay);

                if (light.pointLightOuterRadius >= max)
                {
                    isMax = true;
                    currentRadius = max;
                }
                else if (light.pointLightOuterRadius <= min)
                {
                    isMax = false;
                    currentRadius = min;
                }

                if (isMax)
                {
                    light.pointLightOuterRadius = Mathf.Lerp(currentRadius, min, t);
                }
                else
                {
                    light.pointLightOuterRadius = Mathf.Lerp(currentRadius, max, t);
                }

                yield return null;
            }
        }
    }
}

