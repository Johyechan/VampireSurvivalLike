using Inventory;
using Manager;
using MyUI;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemMakeHandle : MonoBehaviour
{
    public GameObject MakeInventoryItem(ObjectPoolType type, Transform parent)
    {
        GameObject obj = ObjectPoolManager.Instance.GetObject(type, parent);

        RectTransform rectTrans = obj.GetComponent<RectTransform>();
        InventoryItem invenItem = obj.GetComponent<InventoryItem>();
        UIController controller = obj.GetComponent<UIController>();

        rectTrans.sizeDelta = new Vector2(invenItem.so.width * 80, invenItem.so.height * 80); // ���߿� ��� �� ������ ����

        UIManager.Instance.UIs.Add(obj.name, controller);
        
        return obj;
    }
}
