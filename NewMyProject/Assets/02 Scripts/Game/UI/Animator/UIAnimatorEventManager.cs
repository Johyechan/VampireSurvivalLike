using MyUI.Animator.Enum;
using System;

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

