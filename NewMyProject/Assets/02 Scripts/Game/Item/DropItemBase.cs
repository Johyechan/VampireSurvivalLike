using MyUtil.Pool;
using UnityEngine;

public class DropItemBase : MonoBehaviour
{
    [SerializeField] private ObjectPoolType _type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //GameObject uiItem = ObjectPoolManager.Instance.GetObject(_type, );
        }
    }
}
