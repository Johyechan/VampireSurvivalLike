using MyUI.Animator;
using MyUI.Animator.Enum;
using UnityEngine;

namespace MyUI.Button
{
    public class SaveBoxButton : ButtonBase
    {
        [SerializeField] private RectTransform _saveBoxPanel;

        public override void OnClicked()
        {
            UIAnimatorEventManager.Play(UIAnimationType.SaveBoxMoveUp);
        }
    }
}

