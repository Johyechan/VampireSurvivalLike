using Manager;
using MySO;
using MyUI;
using Player;
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
        [HideInInspector] public InventoryItemSO copySO;

        [SerializeField] private float _multiply;

        private GameObject _followIcon;

        private GameObject _mousePointerObj;

        private RectTransform _followIconRectTransform;

        private InventoryItem _followIconItem;

        private UIController _followIconController;

        private PlayerWallet _wallet;

        private int _followIconAlpha = 255;

        private Image _image;

        private bool _isBuy;

        protected override void Awake()
        {
            base.Awake();
            _image = GetComponent<Image>();
            copySO = _so.DeepCopy();
        }

        protected override void Update()
        {
            base.Update();

            _mousePointerObj = UIMousePos(new List<string> { "SaveBox", "Untagged" });

            if(_followIconRectTransform != null)
            {
                if (_mousePointerObj != null && _followIcon != null)
                {
                    ChangeParentAndScale(_mousePointerObj, _followIcon.transform, _followIconRectTransform, copySO, _multiply);
                }

                ItemRotate(_followIconRectTransform, _shape);
            }
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isBuy = true;
            // 이 Ui 아이템 Image 숨기기
            _wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
            if(!_wallet.UseMoney(copySO.price))
            {
                _isBuy = false;
                return;
            }

            UIManager.Instance.UIs[_image.gameObject.name].ChangeAlpha(false, 0.1f);
            UIManager.Instance.UIs[_image.transform.GetChild(0).name].ChangeAlpha(false, 0.1f);
            _followIcon = new GameObject("InventoryItem" + GameManager.Instance.itemNum++);

            // Torch를 추가해야하는데 이런 애들은 어떻게 추가를 해야하는 가 이것은 고민이다
            // 만약 이것의 Tag가 OnlyInven이라면 _followIcon의 Tag도 OnlyInven으로 만든다
            // 그리고 이게 가지고 있던 UIController와 ShopItem이외의 스크립트를 그대로 _followIcon에 넣어주면 된다
            if(gameObject.tag == "OnlyInven")
            {
                _followIcon.tag = "OnlyInven";
                NonCombatItemBase nonCombat = gameObject.GetComponent<NonCombatItemBase>();
                _followIcon.AddComponent(nonCombat.GetType());
            }
            _followIcon.transform.SetParent(_canvas.transform);
            _followIconItem = _followIcon.AddComponent<InventoryItem>();
            _followIconItem.so = _so.DeepCopy();
            _followIconItem.IsShop = true;
            _followIconItem.Multiply = _multiply;
            _shape = _so.DeepCopy().shape;

            _followIconController = _followIcon.AddComponent<UIController>();
            _followIconController.isImage = true;
            _followIconController.alphaValue = 255;

            Image followIconImage = _followIcon.AddComponent<Image>();
            followIconImage.sprite = copySO.sprite;
            followIconImage.color = new Color(_image.color.r, _image.color.g, _image.color.b, _followIconAlpha);
            followIconImage.raycastTarget = false;

            _followIconRectTransform = followIconImage.GetComponent<RectTransform>();
            _followIconRectTransform.sizeDelta = new Vector2(copySO.width * _multiply, copySO.height * _multiply);
            _followIconRectTransform.pivot = new Vector2(0.5f, 0.5f);

            UIManager.Instance.UIs.Add(_followIcon.name, _followIconController);

            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(!_isBuy)
            {
                return;
            }

            UpdateFollowIconPosition(eventData, _followIconRectTransform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!_isBuy)
            {
                return;
            }

            if(!_mousePointerObj.CompareTag("Untagged"))
            {
                if(_mousePointerObj.CompareTag("SaveBox"))
                {
                    // 저장소에 납뒀을 경우
                    _followIconItem.IsShop = false;
                    PlaceSuccssed();
                }
                else
                {
                    InventorySlot slot = _mousePointerObj.GetComponent<InventorySlot>();
                    if(!CanPlaceItem(slot, _shape))
                    {
                        // 이미 차지하고 있는 아이템이 있는 곳에 뒀을 때
                        PlaceFailed();
                    }
                    else
                    {
                        // 인벤토리 슬롯에 납뒀을 경우
                        PlaceItem(_followIcon, slot, _shape, _followIconItem);
                        PlaceSuccssed();
                    }
                }
            }
            else
            {
                // 구매 실패 - 인벤토리 슬롯이나 저장소에 두지 않은 경우
                PlaceFailed();
            }
        }

        private void PlaceSuccssed()
        {
            Image followIconImage = _followIcon.GetComponent<Image>();
            followIconImage.raycastTarget = true;
            _followIcon = null;
            _followIconRectTransform = null;
            _followIconItem = null;
            UIManager.Instance.UIs.Remove(_image.gameObject.name);
            ObjectPoolManager.Instance.ReturnObject(ObjectPoolType.BowIcon, gameObject);
            InventoryManager.Instance.shopCount--;
        }

        private void PlaceFailed()
        {
            _wallet.AddMoney(copySO.price);
            UIManager.Instance.UIs[_image.gameObject.name].ChangeAlpha(true, 0.1f);
            UIManager.Instance.UIs[_image.transform.GetChild(0).name].ChangeAlpha(true, 0.1f);
            UIManager.Instance.UIs.Remove(_followIcon.name);
            Destroy(_followIcon);
            _followIconRectTransform = null;
            _followIconItem = null;
        }
    }
}

