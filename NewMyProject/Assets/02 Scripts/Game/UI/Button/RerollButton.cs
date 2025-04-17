using Manager;
using Manager.UI;
using MyUI.Item;
using MyUtil.Pool;
using UnityEngine;

namespace MyUI.Button
{
    public class RerollButton : ButtonBase
    {
        [SerializeField] private int _price;

        private PlayerWallet _wallet;

        private void Awake()
        {
            _wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
        }

        public override void OnClicked()
        {
            if (_wallet.UseMoney(_price))
            {
                int count = UIManager.Instance.shopItemParent.transform.childCount;

                for (int i = count - 1; i >= 0; i--)
                {
                    UIItem item = UIManager.Instance.shopItemParent.transform.GetChild(i).GetComponent<UIItem>();
                    if (item != null)
                    {
                        ObjectPoolManager.Instance.ReturnObj(item.itemSO.uiObjType, UIManager.Instance.shopItemParent.transform.GetChild(i).gameObject);
                    }
                }

                UIManager.Instance.Refill();
            }
            else
            {
                Debug.Log("µ· ¾øÀ½");
            }
        }
    }
}

