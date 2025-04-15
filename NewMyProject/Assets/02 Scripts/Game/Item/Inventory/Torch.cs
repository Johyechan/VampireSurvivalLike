using Manager;
using MyUI.Item;
using UnityEngine;

namespace Item.Inventory
{
    public class Torch : InventoryItem
    {
        private void Update()
        {
            if(transform.parent.name == "InventoryItems")
            {
                LightManager.Instance.MakePlayerLightBrighter(5, 10);
            }
        }
    }
}

