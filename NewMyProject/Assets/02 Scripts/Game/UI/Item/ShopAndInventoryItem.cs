using Manager.Inventory;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUI.Item
{
    public class ShopAndInventoryItem : UIItem
    {
        private bool _isShop;

        private Vector3 _originPos;

        private List<Vector2Int> _tempGridIndexs;
        private List<Vector2Int> _saveGridIndexs = new List<Vector2Int>();
        public List<Vector2Int> SaveGridIndexs
        {
            get
            {
                return _saveGridIndexs;
            }
        }

        private void OnEnable()
        {
            _isShop = true;
            _originPos = _rectTrans.position;
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            _tempGridIndexs = new List<Vector2Int>(_saveGridIndexs);

            foreach(var index in _saveGridIndexs)
            {
                InventoryManager.Instance.Grid[index.x, index.y].IsOccupied = false;
            }

            _saveGridIndexs.Clear();
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);

            if(!_placement.Place(_rectTrans, _slot, _so.shape, this) || _slot == null)
            {
                _rectTrans.position = _originPos;

                foreach(var index in _tempGridIndexs)
                {
                    _saveGridIndexs.Add(index);
                    InventoryManager.Instance.Grid[index.x, index.y].IsOccupied = true;
                }

                if(_isShop)
                {
                    // µ· µ¹·Á¹Þ±â
                }
            }
            else
            {
                _originPos = _rectTrans.position;
                if (_isShop)
                {
                    _isShop = false;
                }
            }
        }
    }
}

