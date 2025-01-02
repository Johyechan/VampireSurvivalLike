using Inventory;
using MyUI;
using Pool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoSingleton<UIManager>
    {
        private bool _isRunning = false;
        public bool IsRunning { get { return _isRunning; } set { _isRunning = value; } }

        private List<Image> _uiImages = new List<Image>();
        public List<Image> UIImages { get { return _uiImages; } }

        private List<int> _alphaTargets = new List<int>();
        public List<int> AlphaTargets { get { return _alphaTargets; } }

        private UIAnimation _animation;
        private UIMaker _maker;

        protected override void Awake()
        {
            base.Awake();

            _animation = GetComponent<UIAnimation>();
            _maker = GetComponent<UIMaker>();
        }

        public Image[] GetUIImages()
        {
            Image[] images = new Image[_uiImages.Count];
            int count = 0;

            foreach(var image in _uiImages)
            {
                images[count] = image;
                count++;
            }

            return images;
        }

        public int[] GetAlphaTargets()
        {
            int[] alphas = new int[_alphaTargets.Count];
            int count = 0;

            foreach(var alpha in _alphaTargets)
            {
                alphas[count] = alpha;
                count++;
            }

            return alphas;
        }

        public void Appear(Image[] images, float delay, int[] targets, GameObject parent = null)
        {
            _animation.Appear(images, delay, targets, parent);
        }

        public void Disappear(Image[] images, float delay, GameObject parent = null)
        {
            _animation.Disappear(images, delay, parent);
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

