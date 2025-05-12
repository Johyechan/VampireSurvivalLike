using Manager.Inventory;
using MyUtil.Pool;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private ObjectPoolType _uiItemType;
    [SerializeField] private ObjectPoolType _myType;
    [SerializeField] private bool _isWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ObjectPoolManager.Instance.ReturnObj(_myType, gameObject);
            InventoryManager.Instance.AddItemInInventory(_uiItemType, _isWeapon);
        }
    }
}
