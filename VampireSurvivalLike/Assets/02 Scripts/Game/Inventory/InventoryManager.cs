using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Player;
using UnityEngine.UI;
using Inventory;

namespace Manager
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

        public int shopCount;


        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            _maker = GetComponent<InventoryMaker>();
            _grid = new InventorySlot[GameManager.Instance.x, GameManager.Instance.y];
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = _maker.Slots[i, j].GetComponent<InventorySlot>();
                    if (_grid[i, j].IsUsing)
                    {
                        _grid[i, j].IsOccupied = false;
                        _grid[i, j].X = i;
                        _grid[i, j].Y = j;
                    }
                }
            }
        }

        private void Update()
        {
            _maker.MakeInventory();
        }
    }
}

