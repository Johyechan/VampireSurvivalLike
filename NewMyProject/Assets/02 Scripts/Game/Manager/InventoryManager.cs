using MyUI.Slot;
using MyUtil;
using UnityEngine;

namespace Manager.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public InventorySlot[,] Grid { get; set; }
    }
}

