using Manager.UI;
using MyUI.Animator.Enum;
using MyUI.Animator.Interface;
using System.Collections;
using UnityEngine;

namespace MyUI.Animator
{
    public class UISaveBoxMoveAnimator : EventSubscriber, IUIAnimator
    {
        private bool _isPlaying = false;

        private RectTransform _rectTrans;

        private void Awake()
        {
            _rectTrans = GetComponent<RectTransform>();
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
                switch(type)
                {
                    case UIAnimationType.SaveBoxMoveUp:
                        StartCoroutine(MoveToPos(Vector3.zero));
                        break;
                    case UIAnimationType.SaveBoxMoveDown:
                        StartCoroutine(MoveToPos(new Vector3(0, -240, 0)));
                        break;
                }
            }
        }

        private IEnumerator MoveToPos(Vector3 targetPos)
        {
            _isPlaying = true;
            float curTime = 0;
            float delay = 0.5f;
            Vector3 originPos = _rectTrans.anchoredPosition;

            while(curTime < delay)
            {
                curTime += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(curTime / delay);
                _rectTrans.anchoredPosition = Vector3.Lerp(originPos, targetPos, t);
                yield return null;
            }

            _isPlaying = false;
        }
    }
}

