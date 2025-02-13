using Manager;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItem : UIItem, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        public InventoryItemSO so { get; set; }

        private float _multiply;
        public float Multiply { get { return _multiply; } set { _multiply = value; } }

        private bool _isInSaveBox = false;
        private bool _isShop;
        public bool IsShop { get { return _isShop; } set { _isShop = value; } }

        private List<Vector2Int> _tempSaveList;
        private List<Vector2Int> _slots = new List<Vector2Int>();
        public List<Vector2Int> Slots { get { return _slots; } set { _slots = value; } }

        private RectTransform _rectTransform;

        private Vector3 _origin;

        private GameObject _mousePointerObj;

        private Vector2Int[] _tempShape;

        private Quaternion _tempQuaternion;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            if (!_isShop && _rectTransform != null)
            {
                _mousePointerObj = UIMousePos(new List<string> { "Shop", "SaveBox", "Untagged" });

                if(_mousePointerObj != null)
                {
                    ChangeParentAndScale(_mousePointerObj, transform, _rectTransform, so, _multiply);
                }

                ItemRotate(_rectTransform, _shape);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!_isShop)
            {
                _shape = so.shape;
                _tempSaveList = new List<Vector2Int>(_slots);
                RemoveItem(_slots);
                _slots.RemoveAll(slot => slot != null);

                _rectTransform = GetComponent<RectTransform>();
                DeepCopyShape();
                _shape = so.shape;
                if (transform.parent.CompareTag("SaveBox"))
                {
                    _isInSaveBox = true;
                    _origin = _rectTransform.position;
                }
                else
                {
                    _isInSaveBox = false;
                    _origin = _rectTransform.localPosition;
                }

                Image followIconImage = GetComponent<Image>();
                followIconImage.raycastTarget = false;
                UpdateFollowIconPosition(eventData, _rectTransform);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(!_isShop)
            {
                UpdateFollowIconPosition(eventData, _rectTransform);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!_isShop)
            {
                if (!_mousePointerObj.CompareTag("Untagged"))
                {
                    if(_mousePointerObj.CompareTag("Shop"))
                    {
                        // 상점으로 다시 팔았을 때
                        Image image = transform.GetComponent<Image>();
                        UIManager.Instance.UIs.Remove(image.name);
                        Destroy(gameObject);
                        PlayerWallet wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
                        wallet.AddMoney(so.price);
                    }
                    else if(_mousePointerObj.CompareTag("SaveBox"))
                    {
                        // 성공적으로 SaveBox에 옮겼을 경우
                        ItemPlaceSet();
                    }
                    else
                    {
                        InventorySlot slot = _mousePointerObj.GetComponent<InventorySlot>();
                        if(!CanPlaceItem(slot, _shape))
                        {
                            ItemRePlaceFailed();
                            CheckParentIsSaveBox();
                        }
                        else
                        {
                            // 성공적으로 옮겼을 경우
                            PlaceItem(gameObject, slot, _shape, this);
                        }
                        ItemPlaceSet();
                    }
                }
                else
                {
                    ItemRePlaceFailed();
                    CheckParentIsSaveBox();
                    ItemPlaceSet();
                }
            }
        }

        private void ItemRePlaceFailed()
        {
            GetBackItem(_tempSaveList);
            GetBackShape();
            _slots.Clear();
            _slots.AddRange(_tempSaveList);
        }

        private void CheckParentIsSaveBox()
        {
            //Debug.Log($"bool: {_isInSaveBox}, Pos: {_origin}");
            if (_isInSaveBox)
            {
                // 저장소에서 옮겼을 경우 구현
                _rectTransform.sizeDelta = new Vector2(so.width * (_multiply / 2), so.height * (_multiply / 2));
                _rectTransform.position = _origin;
            }
            else
            {
                // 슬롯에 두지 않았을 때
                _rectTransform.localPosition = _origin;
            }
        }

        private void DeepCopyShape()
        {
            _tempQuaternion = new Quaternion(_rectTransform.localRotation.x, _rectTransform.localRotation.y, _rectTransform.localRotation.z, _rectTransform.localRotation.w);

            _tempShape = new Vector2Int[_shape.Length];
            for (int i = 0; i < _shape.Length; i++)
            {
                _tempShape[i] = new Vector2Int(_shape[i].x, _shape[i].y);
            }
        }

        private void GetBackShape()
        {
            _rectTransform.localRotation = new Quaternion(_tempQuaternion.x, _tempQuaternion.y, _tempQuaternion.z, _tempQuaternion.w);

            _shape = new Vector2Int[_tempShape.Length];
            for (int i = 0; i < _tempShape.Length; i++)
            {
                _shape[i] = new Vector2Int(_tempShape[i].x, _tempShape[i].y);
            }
            so.shape = _shape;
        }

        private void ItemPlaceSet()
        {
            Image followIconImage = GetComponent<Image>();
            followIconImage.raycastTarget = true;
            _rectTransform = null;
        }
    }
}

