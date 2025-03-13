using Inventory;
using Manager;
using Player;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyUI
{
    public class ShopRerollButton : BaseButton
    {
        [SerializeField] private InventoryMaker _maker;

        private PlayerWallet _wallet;

        [SerializeField] private int _price;

        private TMP_Text _tmpText; 

        protected override void Start()
        {
            base.Start();
            _wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
            _tmpText = transform.GetChild(0).GetComponent<TMP_Text>();
            _tmpText.text = "$" + _price;
        }

        protected override void Update()
        {
            base.Update();
            if(GameManager.Instance.stage != 0 && GameManager.Instance.stage % 10 == 0)
            {
                _price *= 2;
                _tmpText.text = "$" + _price;
            }
        }

        public override void OnCliked()
        {
            //if (_wallet.ChangeMoney(_price))
            //{
            //    _maker.FillShopItem(true);
            //}
        }
    }
}

