using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Player;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryManager : MonoSingleton<InventoryManager>
    {
        private InventoryMaker _maker;

        private InventorySlot[,] _grid;
        public InventorySlot[,] Grid
        {
            get
            {
                return _grid;
            }
        }

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            _maker = GetComponent<InventoryMaker>();
            _grid = new InventorySlot[_maker.BackpackX, _maker.BackpackY];
            for (int i = 0; i < _maker.BackpackX; i++)
            {
                for (int j = 0; j < _maker.BackpackY; j++)
                {
                    _grid[i, j] = _maker.Slots[i, j].GetComponent<InventorySlot>();
                    _grid[i, j].IsOccupied = false;
                    _grid[i, j].X = i;
                    _grid[i, j].Y = j;
                }
            }
        }

        private void Update()
        {
            _maker.MakeInventory();
        }
    }
}

