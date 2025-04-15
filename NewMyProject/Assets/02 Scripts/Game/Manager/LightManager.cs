using MyUtil;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Manager
{
    public class LightManager : Singleton<LightManager>
    {
        [SerializeField] private Light2D playerLight;

        public void MakePlayerLightBrighter(float innerValue, float outerValue)
        {
            playerLight.pointLightInnerRadius = innerValue;
            playerLight.pointLightOuterRadius = outerValue;
        }
    }
}