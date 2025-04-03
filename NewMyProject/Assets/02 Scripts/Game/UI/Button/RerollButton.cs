using Manager.UI;
using MyUI.Item;
using MyUtil.Pool;
using UnityEngine;

public class RerollButton : ButtonBase
{
    public override void OnClicked()
    {
        int count = UIManager.Instance.shopItemParent.transform.childCount;

        for(int i = count - 1;  i >= 0; i--)
        {
            UIItem item = UIManager.Instance.shopItemParent.transform.GetChild(i).GetComponent<UIItem>();
            if(item != null)
            {
                ObjectPoolManager.Instance.ReturnObj(item.itemSO.objType, UIManager.Instance.shopItemParent.transform.GetChild(i).gameObject);
            }
        }

        UIManager.Instance.OnRefillItems();
    }
}
