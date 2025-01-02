using Manager;
using Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class ShopItem : UIItem, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private InventoryItemSO _so;

        [SerializeField] private float _multiply;

        private GameObject _followIcon;

        private RectTransform _followIconRectTransform;

        private InventoryItem _followIconItem;

        private int _followIconAlpha = 255;

        private Image _image;

        protected override void Awake()
        {
            base.Awake();
            _image = GetComponent<Image>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // 이 Ui 아이템 Image 숨기기
            UIManager.Instance.Disappear(new Image[] { _image }, 0.1f);
            _followIcon = new GameObject("InventoryItem");
            _followIcon.transform.SetParent(_canvas.transform);
            _followIconItem = _followIcon.AddComponent<InventoryItem>();
            _followIconItem.so = _so;
            _followIconItem.so.type = _so.type;
            _shape = _so.shape;

            Image followIconImage = _followIcon.AddComponent<Image>();
            followIconImage.sprite = _so.sprite;
            followIconImage.color = new Color(followIconImage.color.r, followIconImage.color.g, followIconImage.color.b, _followIconAlpha);
            followIconImage.raycastTarget = false;

            _followIconRectTransform = followIconImage.GetComponent<RectTransform>();
            _followIconRectTransform.sizeDelta = new Vector2(_so.width * _multiply, _so.height * _multiply);
            _followIconRectTransform.pivot = new Vector2(0.5f, 0.5f);

            UIManager.Instance.UIImages.Add(followIconImage);
            UIManager.Instance.AlphaTargets.Add(_followIconAlpha);

            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GameObject slotObj = UIMousePos();
            if(slotObj != null)
            {
                InventorySlot slot = slotObj.GetComponent<InventorySlot>();
                if(!PlaceItem(_followIcon, slot, _shape, _followIconItem))
                {
                    // 다시 이 UI 보이기
                    UIManager.Instance.Appear(new Image[] { _image }, 0.1f, new int[] { 255 });
                    Destroy(_followIcon);
                    _followIconRectTransform = null;
                    _followIconItem = null;
                }
                Image followIconImage = _followIcon.GetComponent<Image>();
                followIconImage.raycastTarget = true;
                _followIcon = null;
                _followIconRectTransform = null;
                _followIconItem = null;
                // 이 UI 삭제 
                // 문제는 이게 없어지는 게 아니라는 거임 그냥 수치가 같은 어떤 것이 없어지기 때문에 이걸 고쳐야 함
                UIManager.Instance.UIImages.Remove(_image);
                UIManager.Instance.AlphaTargets.Remove(255);
                ObjectPoolManager.Instance.ReturnObject(ObjectPoolType.GunIcon, gameObject);
            }
            else
            {
                Destroy(_followIcon);
                _followIconRectTransform = null;
                _followIconItem = null;
            }
        }
    }
}

