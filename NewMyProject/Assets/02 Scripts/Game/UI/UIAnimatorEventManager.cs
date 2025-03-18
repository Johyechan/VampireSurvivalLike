using MyUI.Animator.Enum;
using MyUI.Animator.Interface;
using System;
using UnityEngine;

namespace MyUI.Animator
{
    public static class UIAnimatorEventManager
    {
        public static event Action<UIAnimationType> OnPlayAnimation;

        public static void Play(UIAnimationType type)
        {
            OnPlayAnimation?.Invoke(type);
        }
    }
}

