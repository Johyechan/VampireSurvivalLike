using MyUI.Interface;
using MyUI.Item.HandleSystem;
using UnityEngine;

namespace MyUI.Item
{
    public class UIItemPlacement : MonoBehaviour
    {
        private IPlacement _placement;

        private void Awake()
        {
            _placement = new PlacementHandle();
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}

