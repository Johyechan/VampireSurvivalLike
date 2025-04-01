using MyUI.Slot;
using MyUtil;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public InventorySlot[,] Grid { get; set; }

        public Dictionary<string, Queue<Vector2Int>> ItemGrid { get { return _itemGrid; } }
        private Dictionary<string, Queue<Vector2Int>> _itemGrid = new Dictionary<string, Queue<Vector2Int>>();

        public List<GameObject> Items { get { return _items; } }
        private List<GameObject> _items = new List<GameObject>();
    }
}

