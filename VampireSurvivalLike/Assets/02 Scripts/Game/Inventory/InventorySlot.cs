using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool IsOccupied { get{ return b; } set { b = value; } }
        [SerializeField] private bool b;

        public bool IsUsing { get; set; }
    }
}

