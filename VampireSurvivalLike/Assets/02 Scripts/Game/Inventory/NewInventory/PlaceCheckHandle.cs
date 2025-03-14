//using Inventory;
//using Manager;
//using Pool;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlaceCheckHandle : MonoBehaviour
//{
//    public bool CanPlace(GameObject mousePointerObj, )
//    {
//        if (!_mousePointerObj.CompareTag("Untagged"))
//        {
//            if (_mousePointerObj.CompareTag("SaveBox"))
//            {
//                // 저장소에 납뒀을 경우
//                PlaceSuccssed();
//            }
//            else
//            {
//                InventorySlot slot = mousePointerObj.GetComponent<InventorySlot>();
//                if (mousePointerObj.CompareTag("Shop"))
//                {
//                    // 구매 실패 - 인벤토리 슬롯이나 저장소에 두지 않은 경우
//                    PlaceFailed();
//                }
//                else if (!CanPlaceItem(slot, _shape))
//                {
//                    // 이미 차지하고 있는 아이템이 있는 곳에 뒀을 때
//                    PlaceFailed();
//                }
//                else
//                {
//                    // 인벤토리 슬롯에 납뒀을 경우
//                    PlaceItem(_followInvenItem, slot, _shape, _followIconItem);
//                    PlaceSuccssed();
//                }
//            }
//        }
//        else
//        {
//            // 구매 실패 - 인벤토리 슬롯이나 저장소에 두지 않은 경우
//            PlaceFailed();
//        }
//    }

//    private void PlaceSuccssed()
//    {
//        Image followIconImage = _followInvenItem.GetComponent<Image>();
//        followIconImage.raycastTarget = true;

//        InventoryManager.Instance.shopCount--;
//        UIManager.Instance.UIs.Remove(gameObject.name);
//        ObjectPoolManager.Instance.ReturnObject(_so.shopType, gameObject);
//    }

//    private void PlaceFailed()
//    {
//        GameEventManager.OnMoneyUseEvent.EventCall(_so.price);
//        UIManager.Instance.UIs.Remove(_followInvenItem.name);
//        ObjectPoolManager.Instance.ReturnObject(_so.InventoryType, _followInvenItem);
//    }
//}
