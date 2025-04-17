using MyUI.Animator;
using MyUI.Animator.Enum;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.SaveBox
{
    public class SaveBoxPanel : MonoBehaviour, IPointerClickHandler
    {
        private RectTransform _rectTrans;

        private float _lastTime = 0;
        private float _doubleClickTime = 0.25f;

        private void Awake()
        {
            _rectTrans = GetComponent<RectTransform>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            float timeSinceLastClick = Time.unscaledTime - _lastTime;

            if(timeSinceLastClick <= _doubleClickTime)
            {
                UIAnimatorEventManager.Play(UIAnimationType.SaveBoxMoveDown);
            }

            _lastTime = Time.unscaledTime;
        }
    }
}