using Inventory;
using MyUI;
using Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public float delay;

        private bool _isRunning = false;
        public bool IsRunning { get { return _isRunning; } set { _isRunning = value; } }

        private Dictionary<string, UIController> _uis = new Dictionary<string, UIController>();
        public Dictionary<string, UIController> UIs { get { return _uis; } }

        private UIAnimation _animation;
        private UIMaker _maker;

        protected override void Awake()
        {
            base.Awake();

            _animation = GetComponent<UIAnimation>();
            _maker = GetComponent<UIMaker>();
        }

        public void FadeInOut(Image image, float delay, int target)
        {
            _animation.FadeInOut(image, delay, target);
        }

        public void FadeInOut(TMP_Text tmpText, float delay, int target)
        {
            _animation.FadeInOut(tmpText, delay, target);
        }

        public void FadeOutEnd(float delay, GameObject parent)
        {
            _animation.FadeOutEnd(delay, parent);
        }

        public void End(float delay)
        {
            _animation.AnimationEnd(delay);
        }

        public GameObject[,] AddUI(ObjectPoolType type, Transform parent, int x, int y, int width, int height, float spacing, int[,] backpackArr = null)
        {
            return _maker.AddUI(type, parent, x, y, width, height, spacing, backpackArr);
        }

        public void RemoveUI(ObjectPoolType type, Transform parent)
        {
            _maker.RemoveUI(type, parent);
        }
    }
}

