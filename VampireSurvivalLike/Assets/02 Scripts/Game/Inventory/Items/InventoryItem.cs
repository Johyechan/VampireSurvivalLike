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

        private bool _isShop;
        public bool IsShop { get { return _isShop; } set { _isShop = value; } }


        private List<Vector2Int> _slots = new List<Vector2Int>();
        public List<Vector2Int> Slots { get { return _slots; } set { _slots = value; } }


        private RectTransform _rectTransform;

        
        private Vector3 _origin;

        
        private GameObject _mousePointerObj;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            if (!_isShop && _rectTransform != null)
            {
                _mousePointerObj = UIMousePos(new List<string> { "Shop", "SaveBox" });

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
                RemoveItem(_slots);
                _slots.RemoveAll(slot => slot != null);

                _rectTransform = GetComponent<RectTransform>();
                _origin = _rectTransform.localPosition;

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
                if (_mousePointerObj != null)
                {
                    if(_mousePointerObj.CompareTag("Shop"))
                    {
                        // �������� �ٽ� �Ⱦ��� ��
                        Image image = transform.GetComponent<Image>();
                        UIManager.Instance.UIs.Remove(image.name);
                        Destroy(gameObject);
                        PlayerWallet wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
                        wallet.AddMoney(so.price);
                    }
                    else if(_mousePointerObj.CompareTag("SaveBox"))
                    {
                        // ���������� SaveBox�� �Ű��� ���
                        Image followIconImage = GetComponent<Image>();
                        followIconImage.raycastTarget = true;
                        _rectTransform = null;
                    }
                    else
                    {
                        InventorySlot slot = _mousePointerObj.GetComponent<InventorySlot>();

                        if (!PlaceItem(gameObject, slot, _shape, this))
                        {
                            // �̹� �����ϴ� �������� �ִ� ���� ���� ��
                            _rectTransform.localPosition = _origin;
                        }
                        // ���������� �Ű��� ���
                        Image followIconImage = GetComponent<Image>();
                        followIconImage.raycastTarget = true;
                        _rectTransform = null;
                    }
                }
                else
                {
                    // ���Կ� ���� �ʾ��� ��
                    _rectTransform.localPosition = _origin;
                    Image followIconImage = GetComponent<Image>();
                    followIconImage.raycastTarget = true;
                    _rectTransform = null;
                }
            }
        }
    }
}

