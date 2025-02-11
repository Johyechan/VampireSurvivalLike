using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUI
{
    public class SaveBoxButton : BaseButton
    {
        [SerializeField] private SaveBox _saveBox;

        private UIController _controller;

        private void Awake()
        {
            _controller = GetComponent<UIController>();
        }

        public override void OnCliked()
        {
            _saveBox.OpenBox();
            _controller.ChangeAlpha(false);
        }
    }
}

