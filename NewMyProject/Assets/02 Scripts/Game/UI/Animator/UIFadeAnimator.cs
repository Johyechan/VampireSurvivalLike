using MyUI.Animator.Enum;
using MyUI.Animator.Interface;
using System.Collections;
using UnityEngine;

namespace MyUI.Animator
{
    public class UIFadeAnimator : EventSubscriber, IUIAnimator
    {
        private CanvasGroup _canvasGroup;

        private bool _isPlaying = false;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        protected override void SubscribeEvents()
        {
            UIAnimatorEventManager.OnPlayAnimation += Play;
        }

        protected override void UnsubscribeEvents()
        {
            UIAnimatorEventManager.OnPlayAnimation -= Play;
        }

        public void Play(UIAnimationType type)
        {
            if(!_isPlaying)
            {
                switch (type)
                {
                    case UIAnimationType.FadeIn:
                        StartCoroutine(Fade(1, true));
                        break;
                    case UIAnimationType.FadeOut:
                        StartCoroutine(Fade(0, false));
                        break;
                    default:
                        break;
                }
            }
        }

        private IEnumerator Fade(float targetAlpha, bool isFadein)
        {
            _isPlaying = true;

            float currentTime = 0;
            float delay = 0.5f;
            float currentAlpha = _canvasGroup.alpha;

            while (currentTime < delay)
            {
                currentTime += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(currentTime / delay);
                _canvasGroup.alpha = Mathf.Lerp(currentAlpha, targetAlpha, t);
                yield return null;
            }

            _canvasGroup.alpha = targetAlpha;

            _isPlaying = false;
        }
    }
}

