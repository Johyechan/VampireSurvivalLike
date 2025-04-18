using MyUtil;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Manager
{
    public class LightManager : Singleton<LightManager>
    {
        [SerializeField] private Light2D playerLight;

        private float _innerValue;
        private float _outerValue;

        private void Start()
        {
            _innerValue = playerLight.pointLightInnerRadius;
            _outerValue = playerLight.pointLightOuterRadius;
        }

        public void MakePlayerLightBrighter(float innerValue, float outerValue)
        {
            playerLight.pointLightInnerRadius = innerValue;
            playerLight.pointLightOuterRadius = outerValue;
        }

        public void ResetLightBrighter()
        {
            if(_outerValue > 0)
            {
                playerLight.pointLightInnerRadius = _innerValue;
                playerLight.pointLightOuterRadius = _outerValue;
            }
        }
    }
}