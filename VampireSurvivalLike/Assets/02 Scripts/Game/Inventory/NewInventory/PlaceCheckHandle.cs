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
//                // ����ҿ� ������ ���
//                PlaceSuccssed();
//            }
//            else
//            {
//                InventorySlot slot = mousePointerObj.GetComponent<InventorySlot>();
//                if (mousePointerObj.CompareTag("Shop"))
//                {
//                    // ���� ���� - �κ��丮 �����̳� ����ҿ� ���� ���� ���
//                    PlaceFailed();
//                }
//                else if (!CanPlaceItem(slot, _shape))
//                {
//                    // �̹� �����ϰ� �ִ� �������� �ִ� ���� ���� ��
//                    PlaceFailed();
//                }
//                else
//                {
//                    // �κ��丮 ���Կ� ������ ���
//                    PlaceItem(_followInvenItem, slot, _shape, _followIconItem);
//                    PlaceSuccssed();
//                }
//            }
//        }
//        else
//        {
//            // ���� ���� - �κ��丮 �����̳� ����ҿ� ���� ���� ���
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
